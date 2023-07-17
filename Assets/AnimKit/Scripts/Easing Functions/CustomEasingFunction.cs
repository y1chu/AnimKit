//----------------------------------------------------------------------------------------
// CustomEasingFunction.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This abstract scriptable object class serves as a base for creating custom easing functions
//    in Unity. Inherit from this class to define and implement specific easing functions that can
//    be used for interpolating values in animations or other scenarios.
//
// Usage:
//    1. Create a new script by inheriting from CustomEasingFunction.
//    2. Implement the Evaluate(float time) method to define the custom easing behavior.
//    3. Override the Evaluate(float time) method with the desired easing logic.
//    4. Use the Evaluate(float time) method to calculate the modified value of the input time.
//
// Public Methods:
//    - Evaluate(float time): This abstract method must be implemented by derived classes to
//      define the custom easing behavior. It takes a time value (normalized from 0 to 1) and
//      returns the modified value based on the specific easing function logic.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public abstract class CustomEasingFunction : ScriptableObject
{
    // Evaluate the custom easing function at the specified time.
    public abstract float Evaluate(float time);
}