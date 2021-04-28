using Juce.Tween.Easing;
using System;
using UnityEngine;

namespace Juce.Tween
{
    public abstract partial class Tween : ITween
    {
        private int loopsLeft;

        protected EaseDelegate EaseFunction { get; private set; }
        public float TimeScale { get; private set; }

        public int Loops { get; private set; }
        public LoopResetMode LoopResetMode { get; private set; }

        public bool IsNested { get; set; }

        public bool IsPlaying { get; protected set; }
        public bool IsCompleted { get; protected set; }

        public bool IsAlive { get; set; }

        public event Action<float> OnTimeScaleChanged;
        public event Action OnStart;
        public event Action OnLoop;
        public event Action OnReset;
        public event Action OnComplete;
        public event Action OnKill;
        public event Action OnCompleteOrKill;

        public Tween()
        {
            SetEase(Ease.Linear);
            SetTimeScale(1.0f);
        }

        protected void MarkStart()
        {
            IsPlaying = true;
            IsCompleted = false;

            loopsLeft = Loops;

            OnStart?.Invoke();
        }

        protected void MarkFinish(bool canLoop)
        {
            if(!IsPlaying)
            {
                return;
            }

            bool needsToLoop = loopsLeft > 0;

            if (needsToLoop && canLoop)
            {
                --loopsLeft;

                OnLoopFinished(LoopResetMode);

                OnLoop?.Invoke();

                return;
            }

            IsPlaying = false;
            IsCompleted = true;

            OnComplete?.Invoke();
            OnCompleteOrKill?.Invoke();
        }

        protected void MarkKilled()
        {
            if (!IsPlaying)
            {
                return;
            }

            IsPlaying = false;
            IsCompleted = true;

            OnKill?.Invoke();
            OnCompleteOrKill?.Invoke();
        }

        protected void MarkReset()
        {
            IsPlaying = false;
            IsCompleted = false;

            OnReset?.Invoke();
        }

        public void SetTimeScale(float timeScale)
        {
            TimeScale = timeScale;

            OnTimeScaleChanges(timeScale);

            OnTimeScaleChanged?.Invoke(timeScale);
        }

        public void SetEase(EaseDelegate easeFunction)
        {
            EaseFunction = easeFunction;

            OnEaseDelegateChanges(EaseFunction);
        }

        public void SetEase(Ease ease)
        {
            SetEase(PresetEaser.GetEaseDelegate(ease));
        }

        public void SetEase(AnimationCurve animationCurve)
        {
            if (animationCurve == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(SetEase)} " +
                  $"with a null {nameof(AnimationCurve)} on {nameof(Tween)}");
            }

            SetEase(AnimationCurveEaser.GetEaseDelegate(animationCurve));
        }

        public void SetLoops(int loops, LoopResetMode resetMode)
        {
            Loops = Math.Max(loops, 0);
            LoopResetMode = resetMode;
        }

        public void Replay()
        {
            Reset();
            Play();
        }

        public void Play()
        {
            JuceTween.Add(this);
        }

        public abstract void OnEaseDelegateChanges(EaseDelegate easeFunction);
        public abstract void OnTimeScaleChanges(float timeScale);
        public abstract void OnLoopFinished(LoopResetMode loopResetMode);

        public abstract void Start();
        public abstract void Update();

        public abstract void Complete();
        public abstract void Kill();
        public abstract void Reset();
    }
}
