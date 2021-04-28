using Juce.Tween;
using UnityEngine;

public static class JuceTweenRectTransformExtensions
{
    public static ITween TweenAnchorMax(this RectTransform rectTransform, Vector2 to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchorMax, 
            x => rectTransform.anchorMax = x, 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchorMaxX(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchorMax.x,
            x => rectTransform.anchorMax = new Vector2(x, rectTransform.anchorMax.y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchorMaxY(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchorMax.y,
            y => rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchorMin(this RectTransform rectTransform, Vector2 to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchorMin, 
            x => rectTransform.anchorMin = x, 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchorMinX(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchorMin.x,
            x => rectTransform.anchorMin = new Vector2(x, rectTransform.anchorMin.y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchorMinY(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchorMin.y,
            y => rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchoredPosition(this RectTransform rectTransform, Vector2 to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchoredPosition, 
            x => rectTransform.anchoredPosition = x, 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchoredPositionX(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchoredPosition.x,
            x => rectTransform.anchoredPosition = new Vector2(x, rectTransform.anchoredPosition.y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchoredPositionY(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchoredPosition.y,
            y => rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenAnchoredPosition3D(this RectTransform rectTransform, Vector3 to, float duration)
    {
        return Tween.To(
            () => rectTransform.anchoredPosition3D, 
            x => rectTransform.anchoredPosition3D = x, 
            () => to,
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenPivot(this RectTransform rectTransform, Vector2 to, float duration)
    {
        return Tween.To(
            () => rectTransform.pivot, 
            x => rectTransform.pivot = x, 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenSizeDelta(this RectTransform rectTransform, Vector2 to, float duration)
    {
        return Tween.To(
            () => rectTransform.sizeDelta, 
            x => rectTransform.sizeDelta = x, 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenSizeDeltaX(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.sizeDelta.x,
            x => rectTransform.sizeDelta = new Vector2(x, rectTransform.sizeDelta.y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }

    public static ITween TweenSizeDeltaY(this RectTransform rectTransform, float to, float duration)
    {
        return Tween.To(
            () => rectTransform.sizeDelta.y, y => rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, y), 
            () => to, 
            duration,
            () => rectTransform != null
            );
    }
}