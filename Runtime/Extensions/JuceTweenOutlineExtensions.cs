using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;
using UnityEngine.UI;

public static class JuceTweenOutlineExtensions
{
    public static ITween TweenColor(this Outline outline, Color to, float duration)
    {
        return Tween.To(
            () => outline.effectColor, 
            x => outline.effectColor = x, 
            () => to, 
            duration,
            () => outline != null
            );
    }

    public static ITween TweenColorNoAlpha(this Outline outline, Color to, float duration)
    {
        return Tween.To(
            () => outline.effectColor, 
            x => outline.effectColor = ColorUtils.ChangeColorKeepingAlpha(x, outline.effectColor), 
            () => to, 
            duration,
            () => outline != null
            );
    }

    public static ITween TweenColorAlpha(this Outline outline, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => outline.effectColor.a, 
            x => outline.effectColor = ColorUtils.ChangeAlpha(outline.effectColor, x), 
            () => to, 
            duration,
            () => outline != null
            );
    }
}