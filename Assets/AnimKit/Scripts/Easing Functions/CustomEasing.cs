//----------------------------------------------------------------------------------------
// CustomEasing.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script applies custom easing to interpolate the position of a game object between
//    two specified positions. It provides the flexibility to define and use different easing
//    functions for smoother and visually appealing animations in Unity.
//
// Usage:
//    1. Attach this script to the game object you want to animate.
//    2. Set the start position and end position to define the initial and final positions for
//       the movement.
//    3. Adjust the duration to control the time it takes to complete the movement.
//    4. Optionally, assign a custom easing function to the easingFunction delegate for a specific
//       easing effect. If none is provided, the default linear easing is used.
//
// Public Variables:
//    - startPosition: The starting position of the movement.
//    - endPosition: The ending position of the movement.
//    - duration: The duration of the movement.
//
// How it works:
//    - In the Start() method, the script sets the starting position and records the start time.
//      If no custom easing function is assigned, it defaults to linear easing.
//    - In the Update() method, the script calculates the normalized progress value (t) based on
//      the time elapsed since the start of the movement and the specified duration.
//    - The custom easing function (assigned to the easingFunction delegate) is applied to modify
//      the t value.
//    - The position is interpolated between the start position and end position using Vector3.Lerp()
//      function, with the modified t value.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using System;

public class CustomEasing : MonoBehaviour
{
    // Define a delegate that matches the signature of an easing function
    public delegate float EasingFunction(float t);
    public EasingFunction easingFunction;

    public Vector3 startPosition;   // The starting position of the movement.
    public Vector3 endPosition;     // The ending position of the movement.
    public float duration = 1f;     // The duration of the movement.

    private float startTime;        // The start time of the movement.

    void Start()
    {
        // Default to linear easing if none is provided
        if (easingFunction == null)
        {
            easingFunction = Linear;
        }

        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        float t = (Time.time - startTime) / duration;
        t = easingFunction(t); // Apply the custom easing function

        // Interpolate position
        transform.position = Vector3.Lerp(startPosition, endPosition, t);
    }

    // Linear easing function
    float Linear(float t)
    {
        return t;
    }
}
