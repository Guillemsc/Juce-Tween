using Juce.Tween.Easing;
using UnityEngine;

namespace Juce.Tween
{
    public class WaitTimeTween : Tween
    {
        private readonly float duration;
        private float elapsed;

        public WaitTimeTween(float duration)
        {
            this.duration = duration;
        }

        public override void OnTimeScaleChanges(float timeScale)
        {

        }

        public override void OnEaseDelegateChanges(EaseDelegate easeFunction)
        {

        }

        public override void OnLoopFinished(LoopResetMode loopResetMode)
        {
            elapsed = 0.0f;

            MarkLoop();
        }

        public override float OnGetDuration()
        {
            return duration;
        }

        public override float OnGetElapsed()
        {
            return elapsed;
        }

        public override int OnGetTweensCount()
        {
            return 1;
        }

        public override int OnGetPlayingTweensCount()
        {
            return IsPlaying ? 1 : 0;
        }

        public override void Start()
        {
            if (IsPlaying)
            {
                Kill();
            }

            MarkStart();

            elapsed = 0.0f;
        }

        public override void Update()
        {
            float dt = Time.unscaledDeltaTime * JuceTween.TimeScale * TimeScale;

            elapsed += dt;

            if (elapsed >= duration)
            {
                MarkCompleted(canLoop: true);
            }
        }

        public override void Complete()
        {
            if (!IsPlaying && !IsCompleted)
            {
                return;
            }

            elapsed = duration;

            MarkCompleted(canLoop: false);
        }

        public override void Kill()
        {
            elapsed = duration;

            MarkCompleted(canLoop: false);
        }

        public override void Reset()
        {
            Kill();

            elapsed = 0.0f;

            MarkReset();
        }
    }
}
