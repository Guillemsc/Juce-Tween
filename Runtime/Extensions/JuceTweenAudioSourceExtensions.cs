using Juce.Tween;
using UnityEngine;

public static class JuceTweenAudioSourceExtensions
{
    public static ITween TweenVolume(this AudioSource audioSource, float to, float duration)
    {
        return Tween.To(
            () => audioSource.volume, 
            x => audioSource.volume = x, 
            () => to, 
            duration,
            () => audioSource != null
            );
    }

    public static ITween TweenPitch(this AudioSource audioSource, float to, float duration)
    {
        return Tween.To(
            () => audioSource.pitch, 
            x => audioSource.pitch = x, 
            () => to, 
            duration,
            () => audioSource != null
            );
    }
}