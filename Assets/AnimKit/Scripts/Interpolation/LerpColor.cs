//----------------------------------------------------------------------------------------
// LerpColor.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script smoothly interpolates the color of a SpriteRenderer component from a start
//    color to an end color using linear interpolation (lerp). It provides a simple way to
//    create smooth color transitions or animations in Unity.
//
// Usage:
//    1. Attach this script to a game object that has a SpriteRenderer component.
//    2. Adjust the start and end colors as well as the transition duration in the Unity inspector.
//
// Public Variables:
//    - startColor: The starting color of the SpriteRenderer component.
//    - endColor: The end color to which the SpriteRenderer component will be interpolated.
//    - transitionDuration: The duration of the transition from the start color to the end color.
//
// How it works:
//    - The script retrieves the SpriteRenderer component attached to the game object in the
//      Start() method. If it is missing, an error message is logged.
//    - The initial color is set to the start color.
//    - The start time of the transition is recorded.
//    - In the Update() method, the script calculates the time elapsed since the start of the
//      transition and divides it by the transition duration to obtain a normalized progress value
//      (t) between 0 and 1.
//    - Linear interpolation (lerp) is then used to calculate the new color between the start and
//      end colors based on the progress value.
//    - The SpriteRenderer component's color is updated to the new interpolated color.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    // The starting color of the SpriteRenderer component.
    public Color startColor = Color.white;

    // The end color to which the SpriteRenderer component will be interpolated.
    public Color endColor = Color.red;

    // The duration of the transition from the start color to the end color.
    public float transitionDuration = 2.0f;

    private SpriteRenderer spriteRenderer;
    private float transitionStartTime;

    void Start()
    {
        // Retrieve the SpriteRenderer component attached to the game object
        spriteRenderer = GetComponent<SpriteRenderer>();

        if(spriteRenderer == null)
        {
            // Log an error message if the SpriteRenderer component is missing
            Debug.LogError("SpriteRenderer component is missing.");
            return;
        }

        // Set the initial color of the SpriteRenderer component
        spriteRenderer.color = startColor;

        // Record the start time of the transition
        transitionStartTime = Time.time;
    }

    void Update()
    {
        if(spriteRenderer != null)
        {
            // Calculate the progress value (t) based on the time elapsed since the start of the transition
            float t = (Time.time - transitionStartTime) / transitionDuration;

            // Use linear interpolation (lerp) to calculate the new color between the start and end colors
            Color lerpedColor = Color.Lerp(startColor, endColor, t);

            // Update the SpriteRenderer component's color to the new interpolated color
            spriteRenderer.color = lerpedColor;
        }
    }
}
