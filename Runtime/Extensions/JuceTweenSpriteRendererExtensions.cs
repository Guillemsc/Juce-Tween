using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;

public static class JuceTweenSpriteRendererExtensions
{
    public static ITween TweenColor(this SpriteRenderer spriteRenderer, Color to, float duration)
    {
        return Tween.To(
            () => spriteRenderer.color, 
            x => spriteRenderer.color = x, 
            () => to, 
            duration,
            () => spriteRenderer != null
            );
    }

    public static ITween TweenColorNoAlpha(this SpriteRenderer spriteRenderer, Color to, float duration)
    {
        return Tween.To(
            () => spriteRenderer.color, 
            x => spriteRenderer.color = ColorUtils.ChangeColorKeepingAlpha(x, spriteRenderer.color), 
            () => to, 
            duration,
            () => spriteRenderer != null
            );
    }

    public static ITween TweenColorAlpha(this SpriteRenderer spriteRenderer, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => spriteRenderer.color.a, 
            x => spriteRenderer.color =
            ColorUtils.ChangeAlpha(spriteRenderer.color, x), 
            () => to, 
            duration,
            () => spriteRenderer != null
            );
    }
}