//----------------------------------------------------------------------------------------
// CoroutineHelper.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This static class provides helper methods for working with coroutines in Unity.
//
// Usage:
//    1. Call the Lerp() method to create a coroutine that performs a lerping animation over
//       a specified duration using an AnimationCurve.
//
// Public Variables:
//    None.
//
// Public Methods:
//    - Lerp(float duration, AnimationCurve curve, System.Action<float> onUpdate):
//       Creates a coroutine that performs a lerping animation over a specified duration using
//       an AnimationCurve. The onUpdate action is called with the interpolated value at each step.
//
//----------------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;

public static class CoroutineHelper
{
    // Creates a coroutine that performs a lerping animation over a specified duration using an AnimationCurve
    public static IEnumerator Lerp(float duration, AnimationCurve curve, System.Action<float> onUpdate)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            onUpdate(curve.Evaluate(elapsed / duration));
            yield return null;
        }
        onUpdate(curve.Evaluate(1));
    }
}