//----------------------------------------------------------------------------------------
// UIEasingFunctions.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This static class provides various easing functions that can be used for UI animations.
//    Each easing function takes a normalized time value 't' between 0 and 1 and returns an
//    eased value between 0 and 1 based on the specific easing function.
//
// Usage:
//    Use the easing functions in your UI animation scripts to apply different easing effects
//    to the animations.
//
//----------------------------------------------------------------------------------------
public static class UIEasingFunctions 
{
    public static float Linear(float t) 
    {
        return t;
    }

    public static float EaseInQuad(float t) 
    {
        return t * t;
    }

    public static float EaseOutQuad(float t) 
    {
        return t * (2 - t);
    }

    public static float EaseInOutQuad(float t) 
    {
        return t < 0.5f ? 2f * t * t : -1f + (4f - 2f * t) * t;
    }

    public static float EaseInCubic(float t) 
    {
        return t * t * t;
    }

    public static float EaseOutCubic(float t) 
    {
        return (--t) * t * t + 1f;
    }

    public static float EaseInOutCubic(float t) 
    {
        return t < 0.5f ? 4f * t * t * t : (t - 1f) * (2f * t - 2f) * (2f * t - 2f) + 1f;
    }

    // Other easing functions can be added as needed...
}