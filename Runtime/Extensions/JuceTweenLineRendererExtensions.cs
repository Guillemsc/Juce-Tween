using Juce.Tween;
using UnityEngine;

public static class JuceTweenLineRendererExtensions
{
    public static ITween TweenStartColor(this LineRenderer lineRenderer, Color to, float duration)
    {
        return Tween.To(
            () => lineRenderer.startColor, 
            x => lineRenderer.startColor = x, 
            () => to, 
            duration,
            () => lineRenderer != null
            );
    }

    public static ITween TweenEndColor(this LineRenderer lineRenderer, Color to, float duration)
    {
        return Tween.To(
            () => lineRenderer.endColor, 
            x => lineRenderer.endColor = x, 
            () => to, 
            duration,
            () => lineRenderer != null
            );
    }

    public static ITween TweenColor(this LineRenderer lineRenderer, Color to, float duration)
    {
        ITween startTween = TweenStartColor(lineRenderer, to, duration);
        ITween endTween = TweenEndColor(lineRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }

    public static ITween TweenStartWidth(this LineRenderer lineRenderer, float to, float duration)
    {
        return Tween.To(
            () => lineRenderer.startWidth, 
            x => lineRenderer.startWidth = x, 
            () => to, 
            duration,
            () => lineRenderer != null
            );
    }

    public static ITween TweenEndWidth(this LineRenderer lineRenderer, float to, float duration)
    {
        return Tween.To(
            () => lineRenderer.endWidth, 
            x => lineRenderer.endWidth = x, 
            () => to, 
            duration,
            () => lineRenderer != null
            );
    }

    public static ITween TweenWidth(this LineRenderer lineRenderer, float to, float duration)
    {
        ITween startTween = TweenStartWidth(lineRenderer, to, duration);
        ITween endTween = TweenEndWidth(lineRenderer, to, duration);

        GroupTween groupTween = new GroupTween();
        groupTween.Add(startTween);
        groupTween.Add(endTween);

        return groupTween;
    }
}