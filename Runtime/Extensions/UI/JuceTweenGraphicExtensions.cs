using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;
using UnityEngine.UI;

public static class JuceTweenGraphicExtensions
{
    public static ITween TweenColor(this Graphic graphic, Color to, float duration)
    {
        return Tween.To(
            () => graphic.color, 
            x => graphic.color = x, 
            () => to, 
            duration,
            () => graphic != null
            );
    }

    public static ITween TweenColorNoAlpha(this Graphic graphic, Color to, float duration)
    {
        return Tween.To(
            () => graphic.color, 
            x => graphic.color = ColorUtils.ChangeColorKeepingAlpha(x, graphic.color), 
            () => to, 
            duration,
            () => graphic != null
            );
    }

    public static ITween TweenColorAlpha(this Graphic graphic, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => graphic.color.a, 
            x => graphic.color = ColorUtils.ChangeAlpha(graphic.color, x), 
            () => to, 
            duration,
            () => graphic != null
            );
    }
}