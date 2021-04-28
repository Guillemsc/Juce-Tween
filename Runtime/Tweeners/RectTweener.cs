using Juce.Tween.Interpolators;
using UnityEngine;

namespace Juce.Tween.Tweeners
{
    internal class RectTweener : Tweener<Rect>
    {
        internal RectTweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter, setter, finalValueGetter, duration, new RectInterpolator(), validation)
        {
        }
    }
}