//----------------------------------------------------------------------------------------
// ColorInterpolator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script interpolates the color of a game object over time using different easing
//    functions. It allows you to specify a start color, end color, duration, and easing
//    function type for the color transition.
//
// Usage:
//    1. Attach this script to the game object you want to interpolate the color of.
//    2. Set the startColor and endColor to define the initial and final colors.
//    3. Adjust the duration to control the time it takes to complete the color transition.
//    4. Select an easingType from the EasingFunctions.EasingType enum to determine the easing
//       function to use.
//    5. Call the ResetTime() method if you want to restart the color transition.
//
// Public Variables:
//    - startColor: The starting color of the transition.
//    - endColor: The ending color of the transition.
//    - duration: The duration of the color transition.
//    - easingType: The type of easing function to use for the transition.
//
// Private Variables:
//    - elapsedTime: The elapsed time since the start of the color transition.
//
// Public Methods:
//    - Update(): Interpolates the color over time and applies it to the game object.
//    - ResetTime(): Resets the elapsed time and the current color to the start color.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class ColorInterpolator : MonoBehaviour
{
    public Color startColor = Color.white;
    public Color endColor = Color.black;
    public float duration = 1.0f;
    public EasingFunctions.EasingType easingType = EasingFunctions.EasingType.Linear;

    private float elapsedTime = 0f;

    // Interpolates the color over time and applies it to the game object
    private void Update()
    {
        // Increase the elapsed time by the time passed since the last frame
        elapsedTime += Time.deltaTime;

        // Calculate the fraction of the total duration that the elapsed time represents
        float t = elapsedTime / duration;

        // Apply the selected easing function to the fraction 't'
        float easedT = EasingFunctions.ApplyEasing(t, easingType);

        // Interpolate the color
        Color interpolatedColor = Color.Lerp(startColor, endColor, easedT);

        // Apply the interpolated color
        GetComponent<Renderer>().material.color = interpolatedColor;
    }

    // Resets the elapsed time and the current color to the start color
    public void ResetTime()
    {
        elapsedTime = 0f;
        GetComponent<Renderer>().material.color = startColor;
    }
}
