using Juce.Tween.Easing;
using Juce.Tween.Tweeners;
using System;
using System.Collections.Generic;

namespace Juce.Tween
{
    public class InterpolationTween : Tween
    {
        private readonly List<ITweener> tweeners = new List<ITweener>();
        private readonly List<ITweener> playingTweeners = new List<ITweener>();

        public override void OnEaseDelegateChanges(EaseDelegate easeFunction)
        {
            foreach (ITweener tweener in tweeners)
            {
                tweener.SetEase(easeFunction);
            }
        }

        public override void OnTimeScaleChanges(float timeScale)
        {
            foreach(ITweener tweener in tweeners)
            {
                tweener.TimeScale = timeScale;
            }
        }

        public override void OnLoopFinished(LoopResetMode loopResetMode)
        {
            for (int i = tweeners.Count - 1; i >= 0; --i)
            {
                ITweener tweener = tweeners[i];

                tweener.Reset(loopResetMode);
            }

            StartTweeners();
        }

        public override void Start()
        {
            if (IsPlaying)
            {
                Kill();
            }

            MarkStart();

            StartTweeners();
        }

        public override void Update()
        {
            for(int i = playingTweeners.Count - 1; i >= 0; --i)
            {
                ITweener tweener = playingTweeners[i];

                tweener.Update();

                if (!tweener.IsPlaying)
                {
                    playingTweeners.RemoveAt(i);
                }
            }

            if(playingTweeners.Count == 0)
            {
                MarkFinish(canLoop: true);
            }
        }

        public override void Complete()
        {
            if (!IsPlaying)
            {
                Start();
            }

            foreach(ITweener tweener in playingTweeners)
            {
                tweener.Complete();
            }

            playingTweeners.Clear();

            MarkFinish(canLoop: false);
        }

        public override void Kill()
        {
            if (!IsPlaying)
            {
                return;
            }

            foreach (ITweener tweener in playingTweeners)
            {
                tweener.Kill();
            }

            playingTweeners.Clear();

            MarkKilled();
        }

        public override void Reset()
        {
            Kill();

            for (int i = tweeners.Count - 1; i >= 0; --i)
            {
                ITweener tweener = tweeners[i];

                tweener.Reset(LoopResetMode.InitialValues);
            }

            MarkReset();
        }

        public void Add(ITweener tweener)
        {
            if (tweener == null)
            {
                throw new ArgumentNullException($"Tried to {nameof(Add)} a null {nameof(ITweener)} on {nameof(InterpolationTween)}");
            }

            if (tweener.IsPlaying)
            {
                throw new ArgumentNullException($"Tried to {nameof(Add)} a {nameof(ITweener)} on {nameof(InterpolationTween)} " +
                    $"but it was already playing");
            }

            if (tweeners.Contains(tweener))
            {
                throw new ArgumentNullException($"Tried to {nameof(Add)} a {nameof(ITweener)} on {nameof(InterpolationTween)} " +
                    $"but it was already added");
            }

            tweeners.Add(tweener);
        }

        private void StartTweeners()
        {
            playingTweeners.Clear();
            playingTweeners.AddRange(tweeners);

            for (int i = playingTweeners.Count - 1; i >= 0; --i)
            {
                ITweener tweener = playingTweeners[i];

                // Set target

                tweener.SetEase(EaseFunction);

                tweener.Start();

                if (!tweener.IsPlaying)
                {
                    playingTweeners.RemoveAt(i);
                }
            }

            if (playingTweeners.Count == 0)
            {
                MarkFinish(canLoop: true);
            }
        }
    }
}
