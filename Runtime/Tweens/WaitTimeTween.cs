using Juce.Tween.Easing;
using UnityEngine;

namespace Juce.Tween
{
    public class WaitTimeTween : Tween
    {
        private readonly float duration;
        private float elapsedTime;

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
            elapsedTime = 0.0f;
        }

        public override void Start()
        {
            if (IsPlaying)
            {
                Kill();
            }

            MarkStart();

            elapsedTime = 0.0f;
        }

        public override void Update()
        {
            float dt = Time.unscaledDeltaTime * JuceTween.TimeScale * TimeScale;

            elapsedTime += dt;

            if (elapsedTime >= duration)
            {
                MarkFinish(canLoop: true);
            }
        }

        public override void Complete()
        {
            elapsedTime = duration;

            MarkFinish(canLoop: false);
        }

        public override void Kill()
        {
            elapsedTime = duration;

            MarkFinish(canLoop: false);
        }

        public override void Reset()
        {
            Kill();

            elapsedTime = 0.0f;

            MarkReset();
        }
    }
}
