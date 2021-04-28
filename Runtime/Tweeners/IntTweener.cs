using Juce.Tween.Interpolators;

namespace Juce.Tween.Tweeners
{
    public class IntTweener : Tweener<int>
    {
        internal IntTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter, setter, finalValueGetter, duration, new IntInterpolator(), validation)
        {
        }
    }
}