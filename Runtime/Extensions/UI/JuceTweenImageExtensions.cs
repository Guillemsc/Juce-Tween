using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;
using UnityEngine.UI;

public static class JuceTweenImageExtensions
{
    public static ITween TweenColor(this Image image, Color to, float duration)
    {
        return Tween.To(
            () => image.color, 
            x => image.color = x, 
            () => to, 
            duration,
            () => image != null
            );
    }

    public static ITween TweenColorNoAlpha(this Image image, Color to, float duration)
    {
        return Tween.To(
            () => image.color, 
            x => image.color = ColorUtils.ChangeColorKeepingAlpha(x, image.color), 
            () => to, 
            duration,
            () => image != null
            );
    }

    public static ITween TweenColorAlpha(this Image image, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => image.color.a, 
            x => image.color = ColorUtils.ChangeAlpha(image.color, x), 
            () => to, 
            duration,
            () => image != null
            );
    }

    public static ITween TweenFillAmount(this Image image, float to, float duration)
    {
        return Tween.To(
            () => image.fillAmount, 
            x => image.fillAmount = x, 
            () => to, 
            duration,
            () => image != null
            );
    }
}