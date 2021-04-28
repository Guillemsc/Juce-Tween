using Juce.Tween.Easing;

namespace Juce.Tween.Tweeners
{
    public interface ITweener
    {
        float Duration { get; }
        bool UseGeneralTimeScale { get; set; }
        float TimeScale { get; set; }
        float Progress { get; }

        bool IsPlaying { get; }

        void SetEase(EaseDelegate easeFunction);

        void Reset(LoopResetMode mode);
        void Start();
        void Update();
        void Complete();
        void Kill();
    }
}