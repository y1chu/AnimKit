//----------------------------------------------------------------------------------------
// LerpTransform.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script performs linear interpolation (lerp) on the position, rotation, and scale
//    of the attached game object, moving towards a target transform. It provides a simple way
//    to smoothly animate transformations in Unity.
//
// Usage:
//    1. Attach this script to the game object you want to animate.
//    2. Set the targetTransform to the transform you want your game object to move, rotate, and
//       scale towards in the Unity inspector.
//    3. Adjust the positionSpeed, rotationSpeed, and scaleSpeed to control the speed of the
//       transitions.
//
// Public Variables:
//    - targetTransform: The target transform to which the game object will interpolate its
//      position, rotation, and scale.
//    - positionSpeed: The speed of the position transition.
//    - rotationSpeed: The speed of the rotation transition.
//    - scaleSpeed: The speed of the scale transition.
//
// How it works:
//    - In the Update() method, the script checks if a targetTransform is assigned.
//    - If a targetTransform is available, the script performs linear interpolation (lerp) on
//      the position, rotation, and scale of the game object using the specified speeds.
//    - The position is interpolated using Vector3.Lerp(), rotation using Quaternion.Lerp(),
//      and scale using Vector3.Lerp().
//    - The game object gradually moves, rotates, and scales towards the targetTransform.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class LerpTransform : MonoBehaviour
{
    // The target transform to which the game object will interpolate its position, rotation, and scale.
    public Transform targetTransform;

    // The speed of the position transition.
    public float positionSpeed = 1.0f;

    // The speed of the rotation transition.
    public float rotationSpeed = 1.0f;

    // The speed of the scale transition.
    public float scaleSpeed = 1.0f;

    void Update()
    {
        if(targetTransform != null)
        {
            // Perform linear interpolation (lerp) on the position, rotation, and scale

            // Lerp position
            transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * positionSpeed);

            // Lerp rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, Time.deltaTime * rotationSpeed);

            // Lerp scale
            transform.localScale = Vector3.Lerp(transform.localScale, targetTransform.localScale, Time.deltaTime * scaleSpeed);
        }
    }
}
