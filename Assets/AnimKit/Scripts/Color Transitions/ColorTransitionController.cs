//----------------------------------------------------------------------------------------
// ColorTransitionController.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script controls the color transition of a game object using a ColorInterpolator
//    component. It allows you to trigger a color transition by specifying a new end color,
//    duration, and easing type.
//
// Usage:
//    1. Attach this script to the game object you want to control the color transition of.
//    2. Set the startColor and endColor to define the initial and final colors.
//    3. Adjust the duration to control the time it takes to complete the color transition.
//    4. Select an easingType from the EasingFunctions.EasingType enum to determine the easing
//       function to use.
//    5. Call the TriggerColorTransition() method to start a new color transition with the
//       specified parameters.
//
// Public Variables:
//    - startColor: The starting color of the transition.
//    - endColor: The ending color of the transition.
//    - duration: The duration of the color transition.
//    - easingType: The type of easing function to use for the transition.
//
// Private Variables:
//    - colorInterpolator: Reference to the ColorInterpolator component.
//
// Public Methods:
//    - Start(): Initializes the color transition by setting the initial values.
//    - TriggerColorTransition(Color newEndColor, float newDuration,
//       EasingFunctions.EasingType newEasingType): Triggers a new color transition with
//       the specified parameters.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class ColorTransitionController : MonoBehaviour
{
    public Color startColor = Color.white;
    public Color endColor = Color.black;
    public float duration = 1.0f;
    public EasingFunctions.EasingType easingType = EasingFunctions.EasingType.Linear;

    private ColorInterpolator colorInterpolator;

    // Initializes the color transition by setting the initial values
    private void Start()
    {
        colorInterpolator = GetComponent<ColorInterpolator>();
        colorInterpolator.startColor = startColor;
        colorInterpolator.endColor = endColor;
        colorInterpolator.duration = duration;
        colorInterpolator.easingType = easingType;
    }

    // Triggers a new color transition with the specified parameters
    public void TriggerColorTransition(Color newEndColor, float newDuration, EasingFunctions.EasingType newEasingType)
    {
        colorInterpolator.endColor = newEndColor;
        colorInterpolator.duration = newDuration;
        colorInterpolator.easingType = newEasingType;
        colorInterpolator.ResetTime();
    }
}
