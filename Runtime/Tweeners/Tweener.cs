using Juce.Tween.Easing;
using Juce.Tween.Interpolators;
using UnityEngine;

namespace Juce.Tween.Tweeners
{
    public abstract class Tweener<T> : ITweener
    {
        public delegate void Setter(T value);
        public delegate T Getter();
        public delegate bool Validation();

        private readonly IInterpolator<T> interpolator;

        private readonly Getter currValueGetter;
        private readonly Setter setter;
        private readonly Getter finalValueGetter;
        private readonly Validation validation;

        private bool firstTime;
        private T firstTimeInitialValue;
        private T firstTimeFinalValue;

        private T initialValue;
        private T finalValue;

        private EaseDelegate easeFunction;

        public bool IsPlaying { get; protected set; }

        public float Duration { get; }
        public float Elapsed { get; private set; }

        public bool UseGeneralTimeScale { get; set; }
        public float TimeScale { get; set; }

        public Tweener(
            Getter currValueGetter, 
            Setter setter, 
            Getter finalValueGetter, 
            float duration, 
            IInterpolator<T> interpolator,
            Validation validation
            )
        {
            this.currValueGetter = currValueGetter;
            this.setter = setter;
            this.finalValueGetter = finalValueGetter;
            Duration = Mathf.Max(duration, 0.0f);
            this.interpolator = interpolator;
            this.validation = validation;

            firstTime = true;

            UseGeneralTimeScale = true;
            TimeScale = 1.0f;
        }

        public void Start()
        {
            if (IsPlaying)
            {
                return;
            }

            IsPlaying = true;

            Elapsed = 0.0f;

            bool valid = validation();

            if(!valid)
            {
                Kill();

                return;
            }

            initialValue = currValueGetter();
            finalValue = finalValueGetter();

            if (firstTime)
            {
                firstTime = false;

                firstTimeInitialValue = initialValue;
                firstTimeFinalValue = finalValue;
            }

            CompleteIfInstant();
        }

        public void Reset(LoopResetMode mode)
        {
            if (firstTime)
            {
                return;
            }

            bool valid = validation();

            if (!valid)
            {
                Kill();

                return;
            }

            Elapsed = 0.0f;

            switch (mode)
            {
                case LoopResetMode.InitialValues:
                    {
                        setter(firstTimeInitialValue);
                        finalValue = firstTimeFinalValue;
                    }
                    break;

                case LoopResetMode.CurrentValues:
                    {
                        finalValue = firstTimeFinalValue;
                    }
                    break;

                case LoopResetMode.IncrementalValues:
                    {
                        T difference = interpolator.Subtract(firstTimeInitialValue, firstTimeFinalValue);
                        finalValue = interpolator.Add(currValueGetter(), difference);
                    }
                    break;
            }
        }

        public void Update()
        {
            if (!IsPlaying)
            {
                return;
            }

            bool valid = validation();

            if (!valid)
            {
                Kill();

                return;
            }

            float generalTimeScale = UseGeneralTimeScale ? JuceTween.TimeScale : 1.0f;

            float dt = Time.unscaledDeltaTime * generalTimeScale * TimeScale;

            Elapsed += dt;

            if (Elapsed < Duration)
            {
                float timeNormalized = Elapsed / Duration;

                T newValue = interpolator.Evaluate(initialValue, finalValue, timeNormalized, easeFunction);

                setter(newValue);
            }
            else
            {
                Complete();
            }
        }

        public void Complete()
        {
            T newValue = interpolator.Evaluate(initialValue, finalValue, 1.0f, easeFunction);

            setter(newValue);

            IsPlaying = false;
        }

        public void Kill()
        {
            IsPlaying = false;
        }

        public void SetEase(EaseDelegate easeFunction)
        {
            this.easeFunction = easeFunction;
        }

        private void CompleteIfInstant()
        {
            if (!IsPlaying)
            {
                return;
            }

            bool isInstant = Duration == 0.0f;

            if (isInstant)
            {
                Complete();
            }
        }
    }
}