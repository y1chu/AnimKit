//----------------------------------------------------------------------------------------
// ExampleUsage.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script provides an example usage of the ColorTransitionController component.
//    It triggers a new color transition when the space key is pressed, using a random
//    end color and easing function type.
//
// Usage:
//    1. Attach this script to the game object you want to trigger the color transitions.
//    2. Make sure the ColorTransitionController component is attached to the same game object.
//
// Public Variables:
//    None.
//
// Private Variables:
//    - colorTransitionController: Reference to the ColorTransitionController component.
//
// Public Methods:
//    None.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    private ColorTransitionController colorTransitionController;

    // Get the ColorTransitionController component
    private void Start()
    {
        colorTransitionController = GetComponent<ColorTransitionController>();
    }

    // Trigger a new color transition when the space key is pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Randomly generate a new end color
            Color newEndColor = new Color(Random.value, Random.value, Random.value, 1.0f);

            // Randomly select a new easing function type
            EasingFunctions.EasingType newEasingType = (EasingFunctions.EasingType)Random.Range(0, System.Enum.GetValues(typeof(EasingFunctions.EasingType)).Length);

            // Trigger a new color transition with the new end color, a duration of 2 seconds, and the new easing function type
            colorTransitionController.TriggerColorTransition(newEndColor, 2.0f, newEasingType);
        }
    }
}