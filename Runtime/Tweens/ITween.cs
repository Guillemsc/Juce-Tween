﻿using System;
using UnityEngine;

namespace Juce.Tween
{
    public interface ITween
    {
        float TimeScale { get; }

        int Loops { get; }
        LoopResetMode LoopResetMode { get; }

        bool IsPlaying { get; }
        bool IsCompleted { get; }

        event Action<float> OnTimeScaleChanged;
        event Action OnStart;
        event Action OnLoop;
        event Action OnReset;
        event Action OnComplete;
        event Action OnKill;
        event Action OnCompleteOrKill;

        float GetDuration();
        float GetElapsed();
        float GetNormalizedProgress();
        int GetTweensCount();
        int GetPlayingTweensCount();

        void SetTimeScale(float timeScale);

        void SetEase(Ease ease);
        void SetEase(AnimationCurve animationCurve);
        void SetLoops(int loops, LoopResetMode resetMode);

        void Complete();
        void Kill();
        void Reset();

        void Replay();
        void Play();
    }
}
