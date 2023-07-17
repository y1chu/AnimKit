//----------------------------------------------------------------------------------------
// EasingMovement.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script performs easing movement of a game object between two transforms using different
//    easing functions. It provides a way to create smooth and visually appealing animations
//    with various easing effects in Unity.
//
// Usage:
//    1. Attach this script to the game object you want to animate.
//    2. Set the startTransform and endTransform to define the initial and final transforms for
//       the movement.
//    3. Adjust the duration to control the time it takes to complete the movement.
//    4. Set the loop flag to true if you want the movement to loop indefinitely.
//    5. Set the reverse flag to true if you want the movement to reverse after reaching the end.
//    6. Select an easingType from the EasingFunctions.EasingType enum to determine the easing
//       function to use.
//
// Public Variables:
//    - startTransform: The starting transform of the movement.
//    - endTransform: The ending transform of the movement.
//    - duration: The duration of the movement.
//    - loop: Determines whether the movement should loop indefinitely.
//    - reverse: Determines whether the movement should reverse after reaching the end.
//    - easingType: The type of easing function to use.
//
// How it works:
//    - In the Start() method, the script records the start time and applies the initial transform
//      by calling the ApplyTransform() method with the startTransform.
//    - In the Update() method, the script calculates the normalized progress value (t) based on the
//      time elapsed since the start of the movement and the specified duration.
//    - Depending on the loop flag, the t value is either wrapped around using the modulus operator
//      or clamped between 0 and 1 to control looping behavior.
//    - Depending on the reverse flag, the t value is either reversed by subtracting it from 1 or left
//      as is.
//    - The modified t value is then passed to the ApplyEasing() method from the EasingFunctions class
//      to apply the selected easing function.
//    - The position, rotation, and scale are interpolated between the startTransform and endTransform
//      using the modified t value and Vector3.Lerp() and Quaternion.Lerp() functions.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class EasingMovement : MonoBehaviour
{
    // The starting transform of the movement.
    public Transform startTransform;

    // The ending transform of the movement.
    public Transform endTransform;

    // The duration of the movement.
    public float duration = 1f;

    // Determines whether the movement should loop indefinitely.
    public bool loop = false;

    // Determines whether the movement should reverse after reaching the end.
    public bool reverse = false;

    // The type of easing function to use.
    public EasingFunctions.EasingType easingType;

    private float startTime;

    void Start()
    {
        // Record the start time and apply the initial transform
        startTime = Time.time;
        ApplyTransform(startTransform);
    }

    void Update()
    {
        // Calculate the normalized progress value (t) based on the time elapsed
        float t = (Time.time - startTime) / duration;

        // Handle looping behavior
        if (loop)
        {
            t %= 1;
        }
        else if (t > 1)
        {
            t = 1;
        }

        // Handle reverse behavior
        if (reverse)
        {
            t = 1 - t;
        }

        // Apply the selected easing function to modify the t value
        t = EasingFunctions.ApplyEasing(t, easingType);

        // Interpolate position, rotation, and scale between startTransform and endTransform
        transform.position = Vector3.Lerp(startTransform.position, endTransform.position, t);
        transform.rotation = Quaternion.Lerp(startTransform.rotation, endTransform.rotation, t);
        transform.localScale = Vector3.Lerp(startTransform.localScale, endTransform.localScale, t);
    }

    // Applies the specified transform to the game object
    private void ApplyTransform(Transform target)
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
        transform.localScale = target.localScale;
    }
}
