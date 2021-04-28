using Juce.Tween.Interpolators;
using UnityEngine;

namespace Juce.Tween.Tweeners
{
    internal class Vector2Tweener : Tweener<Vector2>
    {
        internal Vector2Tweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter, setter, finalValueGetter, duration, new Vector2Interpolator(), validation)
        {
        }
    }
}