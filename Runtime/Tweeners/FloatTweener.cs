using Juce.Tween.Interpolators;

namespace Juce.Tween.Tweeners
{
    public class FloatTweener : Tweener<float>
    {
        internal FloatTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter, setter, finalValueGetter, duration, new FloatInterpolator(), validation)
        {
        }
    }
}