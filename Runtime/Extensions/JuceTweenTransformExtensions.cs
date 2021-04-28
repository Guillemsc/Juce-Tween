using Juce.Tween;
using Juce.Tween.Utils;
using UnityEngine;

public static class JuceTweenTransformExtensions
{
    public static ITween TweenPosition(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(
            () => transform.position, 
            x => transform.position = x, 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenPositionX(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.position.x,
            x => transform.position = new Vector3(x, transform.position.y, transform.position.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenPositionY(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.position.y,
            y => transform.position = new Vector3(transform.position.x, y, transform.position.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenPositionZ(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.position.z,
            z => transform.position = new Vector3(transform.position.x, transform.position.y, z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalPosition(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(
            () => transform.localPosition, 
            x => transform.localPosition = x, 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalPositionX(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.localPosition.x,
            x => transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalPositionY(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.localPosition.y,
            y => transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalPositionZ(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.localPosition.z,
            z => transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenRotation(this Transform transform, Vector3 to, float duration, RotationMode mode)
    {
        Vector3 finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + AngleUtils.DeltaAngle(finalTo, transform.rotation.eulerAngles);
                }

                return transform.rotation.eulerAngles;
            },
            x => transform.rotation = Quaternion.Euler(x), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenRotationX(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + Mathf.DeltaAngle(finalTo, transform.rotation.eulerAngles.x);
                }

                return transform.rotation.eulerAngles.x;
            },
            x => transform.rotation = Quaternion.Euler(x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenRotationY(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + Mathf.DeltaAngle(finalTo, transform.rotation.eulerAngles.y);
                }

                return transform.rotation.eulerAngles.y;
            },
            y => transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, y, transform.rotation.eulerAngles.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenRotationZ(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + Mathf.DeltaAngle(to, transform.rotation.eulerAngles.z);
                }

                return transform.rotation.eulerAngles.z;
            },
            z => transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalRotation(this Transform transform, Vector3 to, float duration, RotationMode mode)
    {
        Vector3 finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + AngleUtils.DeltaAngle(finalTo, transform.localRotation.eulerAngles);
                }

                return transform.rotation.eulerAngles;
            },
            x => transform.localRotation = Quaternion.Euler(x), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalRotationX(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + Mathf.DeltaAngle(finalTo, transform.localRotation.eulerAngles.x);
                }

                return transform.localRotation.eulerAngles.x;
            },
            x => transform.localRotation = Quaternion.Euler(x, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalRotationY(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + Mathf.DeltaAngle(finalTo, transform.localRotation.eulerAngles.y);
                }

                return transform.localRotation.eulerAngles.y;
            },
            y => transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, y, transform.localRotation.eulerAngles.z),
            () =>
            {
                if (mode == RotationMode.Add)
                {
                    return transform.localRotation.eulerAngles.y + to;
                }

                return to;
            }, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalRotationZ(this Transform transform, float to, float duration, RotationMode mode)
    {
        float finalTo = to;

        if (mode == RotationMode.Fast)
        {
            finalTo = AngleUtils.Clamp360(to);
        }

        return Tween.To(
            () =>
            {
                if (mode == RotationMode.Fast)
                {
                    return finalTo + Mathf.DeltaAngle(finalTo, transform.localRotation.eulerAngles.z);
                }

                return transform.localRotation.eulerAngles.z;
            },
            z => transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalScale(this Transform transform, Vector3 to, float duration)
    {
        return Tween.To(
            () => transform.localScale, 
            x => transform.localScale = x, 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalScaleX(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.localScale.x, 
            x => transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalScaleY(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.localScale.y, 
            y => transform.localScale = new Vector3(transform.localScale.x, y, transform.localScale.z), 
            () => to, 
            duration,
            () => transform != null
            );
    }

    public static ITween TweenLocalScaleZ(this Transform transform, float to, float duration)
    {
        return Tween.To(
            () => transform.localScale.z, 
            z => transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, z), 
            () => to, 
            duration,
            () => transform != null
            );
    }
}