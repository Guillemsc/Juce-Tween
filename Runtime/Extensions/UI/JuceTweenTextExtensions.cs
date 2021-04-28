using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;
using UnityEngine.UI;

public static class JuceTweenTextExtensions
{
    public static ITween TweenColor(this Text text, Color to, float duration)
    {
        return Tween.To(
            () => text.color, 
            x => text.color = x, 
            () => to, 
            duration,
            () => text != null
            );
    }

    public static ITween TweenColorNoAlpha(this Text text, Color to, float duration)
    {
        return Tween.To(
            () => text.color, x => text.color = ColorUtils.ChangeColorKeepingAlpha(x, text.color), 
            () => to, 
            duration,
            () => text != null
            );
    }

    public static ITween TweenColorAlpha(this Text text, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => text.color.a, x => text.color = ColorUtils.ChangeAlpha(text.color, x), 
            () => to, 
            duration,
            () => text != null
            );
    }
}