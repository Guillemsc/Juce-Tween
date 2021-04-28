using Juce.Tween.Easing;
using System;

namespace Juce.Tween
{
    public class ResetableCallbackTween : Tween
    {
        private readonly Action action;
        private readonly Action resetAction;

        public ResetableCallbackTween(Action action, Action resetAction)
        {
            this.action = action;
            this.resetAction = resetAction;
        }

        public override void OnTimeScaleChanges(float timeScale)
        {

        }

        public override void OnEaseDelegateChanges(EaseDelegate easeFunction)
        {

        }

        public override void OnLoopFinished(LoopResetMode loopResetMode)
        {
            resetAction?.Invoke();
        }

        public override void Start()
        {
            if (IsPlaying)
            {
                Kill();
            }

            MarkStart();

            action?.Invoke();

            MarkFinish(canLoop: true);
        }

        public override void Update()
        {

        }

        public override void Complete()
        {
            if (!IsPlaying)
            {
                MarkStart();

                action?.Invoke();
            }

            MarkFinish(canLoop: false);
        }

        public override void Kill()
        {
            MarkKilled();
        }

        public override void Reset()
        {
            resetAction?.Invoke();

            MarkReset();
        }
    }
}
