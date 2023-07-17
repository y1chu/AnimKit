//----------------------------------------------------------------------------------------
// TransformInterpolation.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script performs linear interpolation (lerp) on the position, rotation, and scale
//    of the attached game object, gradually transitioning towards a target transform. It
//    provides a simple way to smoothly animate transformations in Unity.
//
// Usage:
//    1. Attach this script to the game object you want to animate.
//    2. Set the targetTransform to the transform you want your game object to interpolate its
//       position, rotation, and scale towards in the Unity inspector.
//    3. Adjust the transitionDuration to control the duration of the transitions.
//    4. Call the StartInterpolation() method to start the interpolation.
//
// Public Variables:
//    - targetTransform: The target transform to which the game object will interpolate its
//      position, rotation, and scale.
//    - transitionDuration: The duration of the transitions.
//
// Public Methods:
//    - StartInterpolation: Starts the interpolation by calling the appropriate lerp
//      coroutines for position, rotation, and scale.
//
// Coroutine Methods:
//    - LerpPosition: Coroutine that performs linear interpolation on the position.
//    - LerpRotation: Coroutine that performs linear interpolation on the rotation.
//    - LerpScale: Coroutine that performs linear interpolation on the scale.
//
// How it works:
//    - The StartInterpolation() method is called to start the interpolation.
//    - The lerp coroutines are started using StartCoroutine(), which allows for smooth
//      transitions over time.
//    - Each lerp coroutine gradually transitions the position, rotation, or scale of the game
//      object towards the target transform by performing linear interpolation (lerp) over the
//      specified transition duration.
//    - The elapsed time is tracked using the 'elapsed' variable, and the lerp value is
//      calculated as elapsed time divided by the transition duration.
//    - Inside the lerp coroutines, the game object's position, rotation, or scale is updated
//      using the interpolated values.
//    - Once the interpolation is complete, the final position, rotation, or scale is set to
//      ensure an accurate match with the target transform.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class TransformInterpolation : MonoBehaviour
{
    // The target transform to which the game object will interpolate its position, rotation, and scale.
    public Transform targetTransform;

    // The duration of the transitions.
    public float transitionDuration = 1f;

    // Coroutine that performs linear interpolation on the position.
    public IEnumerator LerpPosition()
    {
        Vector3 startPosition = transform.position;
        float elapsed = 0;

        while (elapsed < transitionDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetTransform.position, elapsed / transitionDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetTransform.position;
    }

    // Coroutine that performs linear interpolation on the rotation.
    public IEnumerator LerpRotation()
    {
        Quaternion startRotation = transform.rotation;
        float elapsed = 0;

        while (elapsed < transitionDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetTransform.rotation, elapsed / transitionDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetTransform.rotation;
    }

    // Coroutine that performs linear interpolation on the scale.
    public IEnumerator LerpScale()
    {
        Vector3 startScale = transform.localScale;
        float elapsed = 0;

        while (elapsed < transitionDuration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetTransform.localScale, elapsed / transitionDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetTransform.localScale;
    }

    // Starts the interpolation by calling the appropriate lerp coroutines for position, rotation, and scale.
    public void StartInterpolation()
    {
        StartCoroutine(LerpPosition());
        StartCoroutine(LerpRotation());
        StartCoroutine(LerpScale());
    }
}
