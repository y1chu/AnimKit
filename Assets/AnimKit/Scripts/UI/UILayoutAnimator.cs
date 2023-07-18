//----------------------------------------------------------------------------------------
// UILayoutAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script animates the layout of a UI element, such as position, size, scale, and rotation.
//    It uses the RectTransform component to modify the properties of the UI element over a specified
//    duration using an easing curve.
//
// Usage:
//    1. Attach this script to the UI element you want to animate.
//    2. Set the target RectTransform and the desired target position, size, scale, and rotation
//       in the inspector.
//    3. Set the duration and easing curve for the animation.
//    4. Call the AnimateLayout() method to start the animation.
//
//    Note: Make sure the UI element has the RectTransform component for layout modifications.
//
//----------------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UILayoutAnimator : MonoBehaviour
{
    public RectTransform target;
    public Vector2 targetPosition;
    public Vector2 targetSize;
    public Vector3 targetScale;
    public Vector3 targetRotation;
    public float duration = 1f;
    public AnimationCurve easing = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    public void AnimateLayout()
    {
        StartCoroutine(LayoutAnimation());
    }

    private IEnumerator LayoutAnimation()
    {
        Vector2 startPosition = target.anchoredPosition;
        Vector2 startSize = target.sizeDelta;
        Vector3 startScale = target.localScale;
        Vector3 startRotation = target.localEulerAngles;

        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            float easedTime = easing.Evaluate(normalizedTime);

            target.anchoredPosition = Vector2.LerpUnclamped(startPosition, targetPosition, easedTime);
            target.sizeDelta = Vector2.LerpUnclamped(startSize, targetSize, easedTime);
            target.localScale = Vector3.LerpUnclamped(startScale, targetScale, easedTime);
            target.localEulerAngles = Vector3.LerpUnclamped(startRotation, targetRotation, easedTime);

            yield return null;
        }

        target.anchoredPosition = targetPosition;
        target.sizeDelta = targetSize;
        target.localScale = targetScale;
        target.localEulerAngles = targetRotation;
    }
}
