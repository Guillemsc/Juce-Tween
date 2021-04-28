using Juce.Tween;
using UnityEngine;
using UnityEngine.UI;

public static class JuceTweenScrollRectExtensions
{
    public static ITween TweenNormalizedPosition(this ScrollRect scrollRect, Vector2 to, float duration)
    {
        return Tween.To(
            () => scrollRect.normalizedPosition, 
            x => scrollRect.normalizedPosition = x, 
            () => to, 
            duration,
            () => scrollRect != null
            );
    }

    public static ITween TweenHorizontalNormalizedPosition(this ScrollRect scrollRect, float to, float duration)
    {
        return Tween.To(
            () => scrollRect.horizontalNormalizedPosition, 
            x => scrollRect.horizontalNormalizedPosition = x, 
            () => to, 
            duration,
            () => scrollRect != null
            );
    }

    public static ITween TweenVerticalNormalizedPosition(this ScrollRect scrollRect, float to, float duration)
    {
        return Tween.To(
            () => scrollRect.verticalNormalizedPosition, 
            x => scrollRect.verticalNormalizedPosition = x, 
            () => to, 
            duration,
            () => scrollRect != null
            );
    }
}