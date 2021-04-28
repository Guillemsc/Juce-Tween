using Juce.Tween.Interpolators;
using UnityEngine;

namespace Juce.Tween.Tweeners
{
    internal class Vector3Tweener : Tweener<Vector3>
    {
        internal Vector3Tweener(Getter currValueGetter, Setter setter, Getter finalValueGetter, float duration, Validation validation)
            : base(currValueGetter, setter, finalValueGetter, duration, new Vector3Interpolator(), validation)
        {
        }
    }
}