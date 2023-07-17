//----------------------------------------------------------------------------------------
// EasingFunctions.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This static class provides various easing functions that modify the input value 't' to
//    create different interpolation effects. These easing functions can be used to control
//    the speed of transitions and create smooth animations in Unity.
//
// Easing Functions:
//    - Linear: Linear easing function that returns the input value 't' as is.
//    - EaseInQuad: Easing function that starts slow and accelerates using a quadratic curve.
//    - EaseOutQuad: Easing function that starts fast and decelerates using a quadratic curve.
//    - EaseInOutQuad: Easing function that starts slow, accelerates, then decelerates using a
//      quadratic curve.
//    - EaseInCubic: Easing function that starts slow and accelerates using a cubic curve.
//    - EaseOutCubic: Easing function that starts fast and decelerates using a cubic curve.
//    - EaseInOutCubic: Easing function that starts slow, accelerates, then decelerates using a
//      cubic curve.
//
// Usage:
//    - Use the ApplyEasing() method to apply the selected easing function to the input value 't'.
//    - Pass the input value 't' and the desired easing type from the EasingType enum as arguments.
//
// Public Variables:
//    - EasingType: An enum that defines different easing types.
//
// Public Methods:
//    - ApplyEasing: Applies the specified easing function to the input value 't' based on the
//      selected easing type.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public static class EasingFunctions
{
    // An enum that defines different easing types
    public enum EasingType
    {
        Linear,
        EaseInQuad,
        EaseOutQuad,
        EaseInOutQuad,
        EaseInCubic,
        EaseOutCubic,
        EaseInOutCubic
    }

    // Applies the specified easing function to the input value 't' based on the selected easing type
    public static float ApplyEasing(float t, EasingType easingType)
    {
        switch (easingType)
        {
            case EasingType.EaseInQuad:
                return EaseInQuad(t);
            case EasingType.EaseOutQuad:
                return EaseOutQuad(t);
            case EasingType.EaseInOutQuad:
                return EaseInOutQuad(t);
            case EasingType.EaseInCubic:
                return EaseInCubic(t);
            case EasingType.EaseOutCubic:
                return EaseOutCubic(t);
            case EasingType.EaseInOutCubic:
                return EaseInOutCubic(t);
            default:
                return Linear(t);
        }
    }

    // Linear easing
    public static float Linear(float t)
    {
        // Linear easing returns the input value 't' as is
        return t;
    }

    // Ease-In Quad
    public static float EaseInQuad(float t)
    {
        // Easing function that starts slow and accelerates using a quadratic curve
        return t * t;
    }

    // Ease-Out Quad
    public static float EaseOutQuad(float t)
    {
        // Easing function that starts fast and decelerates using a quadratic curve
        return t * (2 - t);
    }

    // Ease-In-Out Quad
    public static float EaseInOutQuad(float t)
    {
        // Easing function that starts slow, accelerates, then decelerates using a quadratic curve
        return t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t;
    }

    // Ease-In Cubic
    public static float EaseInCubic(float t)
    {
        // Easing function that starts slow and accelerates using a cubic curve
        return t * t * t;
    }

    // Ease-Out Cubic
    public static float EaseOutCubic(float t)
    {
        // Easing function that starts fast and decelerates using a cubic curve
        return (--t) * t * t + 1;
    }

    // Ease-In-Out Cubic
    public static float EaseInOutCubic(float t)
    {
        // Easing function that starts slow, accelerates, then decelerates using a cubic curve
        return t < 0.5f ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;
    }
}
