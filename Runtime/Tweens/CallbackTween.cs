﻿using Juce.Tween.Easing;
using System;

namespace Juce.Tween
{
    public class CallbackTween : Tween
    {
        private readonly Action action;

        public CallbackTween(Action action)
        {
            this.action = action;
        }

        public override void OnTimeScaleChanges(float timeScale)
        {
 
        }

        public override void OnEaseDelegateChanges(EaseDelegate easeFunction)
        {
  
        }

        public override void OnLoopFinished(LoopResetMode loopResetMode)
        {

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
            MarkReset();
        }
    }
}
