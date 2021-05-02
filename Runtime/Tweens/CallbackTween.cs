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
            MarkLoop();
        }

        public override float OnGetDuration()
        {
            return 0.0f;
        }

        public override float OnGetElapsed()
        {
            return 0.0f;
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

            action?.Invoke();

            MarkCompleted(canLoop: true);
        }

        public override void Update()
        {
  
        }

        public override void Complete()
        {
            if (!IsPlaying && !IsCompleted)
            {
                Start();
            }

            MarkCompleted(canLoop: false);
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
