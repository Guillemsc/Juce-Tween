using Juce.Tween;
using UnityEngine;

public static class JuceTweenRigidbodyExtensions
{
    public static ITween TweenPosition(this Rigidbody rigidbody, Vector3 to, float duration)
    {
        return Tween.To(
            () => rigidbody.position, 
            x => rigidbody.MovePosition(x), 
            () => to, 
            duration,
            () => rigidbody != null
            );
    }

    public static ITween TweenRotation(this Rigidbody rigidbody, Vector3 to, float duration)
    {
        return Tween.To(
            () => rigidbody.rotation.eulerAngles, 
            x => rigidbody.MoveRotation(Quaternion.Euler(x)), 
            () => to, 
            duration,
            () => rigidbody != null
            );
    }
}