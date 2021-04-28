using Juce.Tween;
using UnityEngine;

public static class JuceTweenRigidBody2DExtensions
{
    public static ITween TweenPosition(this Rigidbody2D rigidbody, Vector2 to, float duration)
    {
        return Tween.To(
            () => rigidbody.position, 
            x => rigidbody.MovePosition(x), 
            () => to, 
            duration,
            () => rigidbody != null
            );
    }

    public static ITween TweenRotation(this Rigidbody rigidbody, Vector2 to, float duration)
    {
        return Tween.To(
            () => (Vector2)rigidbody.rotation.eulerAngles, 
            x => rigidbody.MoveRotation(Quaternion.Euler(x)), 
            () => to, 
            duration,
            () => rigidbody != null
            );
    }
}