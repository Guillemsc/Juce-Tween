using Juce.Tween;
using UnityEngine;

public static class JuceTweenLightExtensions
{
    public static ITween TweenColor(this Light light, Color to, float duration)
    {
        return Tween.To(
            () => light.color, 
            x => light.color = x, 
            () => to, 
            duration,
            () => light != null
            );
    }

    public static ITween TweenIntensity(this Light light, float to, float duration)
    {
        return Tween.To(
            () => light.intensity, 
            x => light.intensity = x, 
            () => to, 
            duration,
            () => light != null
            );
    }

    public static ITween TweenShadowStrenght(this Light light, float to, float duration)
    {
        return Tween.To(
            () => light.shadowStrength, x => light.shadowStrength = x, 
            () => to, 
            duration,
            () => light != null
            );
    }
}