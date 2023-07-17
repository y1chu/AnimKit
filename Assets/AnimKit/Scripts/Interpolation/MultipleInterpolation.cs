//----------------------------------------------------------------------------------------
// MultipleInterpolation.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script performs linear interpolation (lerp) on the position, rotation, and scale
//    of the attached game object, allowing control over which transformations to interpolate.
//    It provides a way to selectively animate specific transformations in Unity.
//
// Usage:
//    1. Attach this script to the game object you want to animate.
//    2. Set the targetTransform to the transform you want your game object to interpolate its
//       position, rotation, and scale towards in the Unity inspector.
//    3. Adjust the interpolatePosition, interpolateRotation, and interpolateScale booleans
//       to control which transformations should be interpolated.
//    4. Adjust the speed to control the speed of the interpolation.
//
// Public Variables:
//    - targetTransform: The target transform to which the game object will interpolate its
//      position, rotation, and scale.
//    - interpolatePosition: Determines whether to interpolate the position.
//    - interpolateRotation: Determines whether to interpolate the rotation.
//    - interpolateScale: Determines whether to interpolate the scale.
//    - speed: The speed of the interpolation.
//
// How it works:
//    - In the Update() method, the script checks if a targetTransform is assigned.
//    - If a targetTransform is available, the script performs linear interpolation (lerp) on
//      the position, rotation, and scale of the game object if the respective interpolation
//      flag is set to true.
//    - The interpolation is controlled by the speed variable, which determines the speed at
//      which the game object transitions towards the targetTransform.
//    - The position, rotation, and scale are interpolated using Vector3.Lerp() and
//      Quaternion.Lerp() functions based on the specified speed and Time.deltaTime.
//    - By adjusting the interpolatePosition, interpolateRotation, and interpolateScale flags,
//      you can selectively choose which transformations to interpolate.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class MultipleInterpolation : MonoBehaviour
{
    // The target transform to which the game object will interpolate its position, rotation, and scale.
    public Transform targetTransform;

    // Determines whether to interpolate the position.
    public bool interpolatePosition = true;

    // Determines whether to interpolate the rotation.
    public bool interpolateRotation = true;

    // Determines whether to interpolate the scale.
    public bool interpolateScale = true;

    // The speed of the interpolation.
    public float speed = 1.0f;

    void Update()
    {
        if (targetTransform != null)
        {
            // Lerp position if interpolatePosition is true
            if (interpolatePosition)
            {
                transform.position = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * speed);
            }

            // Lerp rotation if interpolateRotation is true
            if (interpolateRotation)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetTransform.rotation, Time.deltaTime * speed);
            }

            // Lerp scale if interpolateScale is true
            if (interpolateScale)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, targetTransform.localScale, Time.deltaTime * speed);
            }
        }
    }
}
