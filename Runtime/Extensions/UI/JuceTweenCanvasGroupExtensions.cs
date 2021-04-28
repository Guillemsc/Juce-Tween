using Juce.Tween;
using UnityEngine;

public static class JuceTweenCanvasGroupExtensions
{
    public static ITween TweenAlpha(this CanvasGroup canvasGroup, float to, float duration)
    {
        return Tween.To(
            () => canvasGroup.alpha, 
            x => canvasGroup.alpha = x, 
            () => to, 
            duration,
            () => canvasGroup != null
            );
    }
}