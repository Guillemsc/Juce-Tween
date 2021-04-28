using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;

public static class JuceTweenCameraExtensions
{
    public static ITween TweenAspect(this Camera camera, float to, float duration)
    {
        return Tween.To(
            () => camera.aspect, 
            x => camera.aspect = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenBackgroundColor(this Camera camera, Color to, float duration)
    {
        return Tween.To(
            () => camera.backgroundColor, 
            x => camera.backgroundColor = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenBackgroundColorNoAlpha(this Camera camera, Color to, float duration)
    {
        return Tween.To(
            () => camera.backgroundColor, 
            x => camera.backgroundColor = ColorUtils.ChangeColorKeepingAlpha(x, camera.backgroundColor), 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenBackgroundColorAlpha(this Camera camera, float to, float duration)
    {
        float to255 = to * 255.0f;

        return Tween.To(
            () => camera.backgroundColor.a, 
            x => camera.backgroundColor = ColorUtils.ChangeAlpha(camera.backgroundColor, x), 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenFarClipPlane(this Camera camera, float to, float duration)
    {
        return Tween.To(
            () => camera.farClipPlane, 
            x => camera.farClipPlane = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenNearClipPlane(this Camera camera, float to, float duration)
    {
        return Tween.To(
            () => camera.nearClipPlane, 
            x => camera.nearClipPlane = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenFieldOfView(this Camera camera, float to, float duration)
    {
        return Tween.To(
            () => camera.fieldOfView, 
            x => camera.fieldOfView = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenOrthoSize(this Camera camera, float to, float duration)
    {
        return Tween.To(
            () => camera.orthographicSize, 
            x => camera.orthographicSize = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenRect(this Camera camera, Rect to, float duration)
    {
        return Tween.To(
            () => camera.rect, 
            x => camera.rect = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }

    public static ITween TweenPixelRect(this Camera camera, Rect to, float duration)
    {
        return Tween.To(
            () => camera.pixelRect, 
            x => camera.pixelRect = x, 
            () => to, 
            duration,
            () => camera != null
            );
    }
}