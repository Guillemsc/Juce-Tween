using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;

public static class JuceTweenTrailRendererExtensions
{
    public static ITween TweenTime(this TrailRenderer trailRenderer, float to, float duration)
    {
        return Tween.To(
            () => trailRenderer.time, 
            x => trailRenderer.time = x, 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenStartColor(this TrailRenderer trailRenderer, Color to, float duration)
    {
        return Tween.To(
            () => trailRenderer.startColor, 
            x => trailRenderer.startColor = x, 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenEndColor(this TrailRenderer trailRenderer, Color to, float duration)
    {
        return Tween.To(
            () => trailRenderer.endColor, 
            x => trailRenderer.endColor = x, 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenColor(this TrailRenderer trailRenderer, Color to, float duration)
    {
        ITween startTween = TweenStartColor(trailRenderer, to, duration);
        ITween endTween = TweenEndColor(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static ITween TweenStartColorNoAlpha(this TrailRenderer trailRenderer, Color to, float duration)
    {
        return Tween.To(
            () => trailRenderer.startColor, 
            x => trailRenderer.startColor = ColorUtils.ChangeColorKeepingAlpha(x, trailRenderer.startColor), 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenEndColorNoAlpha(this TrailRenderer trailRenderer, Color to, float duration)
    {
        return Tween.To(
            () => trailRenderer.endColor, 
            x => trailRenderer.endColor = ColorUtils.ChangeColorKeepingAlpha(x, trailRenderer.endColor), 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenColorNoAlpha(this TrailRenderer trailRenderer, Color to, float duration)
    {
        ITween startTween = TweenStartColorNoAlpha(trailRenderer, to, duration);
        ITween endTween = TweenEndColorNoAlpha(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static ITween TweenStartColorAlpha(this TrailRenderer trailRenderer, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => trailRenderer.startColor.a, 
            x => trailRenderer.startColor = ColorUtils.ChangeAlpha(trailRenderer.startColor, x), 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenEndColorAlpha(this TrailRenderer trailRenderer, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => trailRenderer.endColor.a, 
            x => trailRenderer.endColor = ColorUtils.ChangeAlpha(trailRenderer.endColor, x), 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenColorAlpha(this TrailRenderer trailRenderer, float to, float duration)
    {
        ITween startTween = TweenStartColorAlpha(trailRenderer, to, duration);
        ITween endTween = TweenEndColorAlpha(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static ITween TweenStartWidth(this TrailRenderer trailRenderer, float to, float duration)
    {
        return Tween.To(
            () => trailRenderer.startWidth, 
            x => trailRenderer.startWidth = x, 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenEndWidth(this TrailRenderer trailRenderer, float to, float duration)
    {
        return Tween.To(
            () => trailRenderer.endWidth, 
            x => trailRenderer.endWidth = x, 
            () => to, 
            duration,
            () => trailRenderer != null
            );
    }

    public static ITween TweenWidth(this TrailRenderer trailRenderer, float to, float duration)
    {
        ITween startTween = TweenStartWidth(trailRenderer, to, duration);
        ITween endTween = TweenEndWidth(trailRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }
}