using System;

namespace Juce.Tween
{
    public interface ISequenceTween : ITween
    {
        void Append(ITween tween);
        void Join(ITween tween);
        void AppendCallback(Action callback);
        void JoinCallback(Action callback);
        void AppendResetableCallback(Action callback, Action reset);
        void JoinResetableCallback(Action callback, Action reset);
    }
}
