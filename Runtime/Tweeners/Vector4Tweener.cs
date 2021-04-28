using Juce.Tween.Interpolators;
using UnityEngine;

namespace Juce.Tween.Tweeners
{
    internal class Vector4Tweener : Tweener<Vector4>
    {
        internal Vector4Tweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter, setter, finalValueGetter, duration, new Vector4Interpolator(), validation)
        {
        }
    }
}