using Juce.Tween.Interpolators;
using UnityEngine;

namespace Juce.Tween.Tweeners
{
    public class ColorTweener : Tweener<Color>
    {
        internal ColorTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter, setter, finalValueGetter, duration, new ColorInterpolator(), validation)
        {
        }
    }
}