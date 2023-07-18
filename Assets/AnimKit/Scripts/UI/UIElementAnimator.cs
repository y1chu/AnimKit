//----------------------------------------------------------------------------------------
// UIElementAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script provides animation functionalities for UI elements, allowing you to animate
//    position, scale, rotation, and opacity. It uses the CoroutineHelper class to perform
//    the animations over a specified duration using an animation curve for easing.
//
// Usage:
//    1. Attach this script to the UI element you want to animate.
//    2. Set the duration and animation curve in the inspector.
//    3. Call the appropriate animation methods to animate the desired properties of the UI
//       element.
//
//    Note: Make sure the UI element has the required components (e.g., Image) for the
//    corresponding animations.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class UIElementAnimator : MonoBehaviour
{
    public float duration = 1.0f;
    public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private float originalOpacity;

    private void Start()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
        originalScale = transform.localScale;
        originalOpacity = GetComponent<Image>().color.a;
    }

    public void AnimatePosition(Vector3 targetPosition)
    {
        StartCoroutine(CoroutineHelper.Lerp(duration, animationCurve, percent =>
        {
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, percent);
        }));
    }

    public void AnimateScale(Vector3 targetScale)
    {
        StartCoroutine(CoroutineHelper.Lerp(duration, animationCurve, percent =>
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, percent);
        }));
    }

    public void AnimateRotation(Quaternion targetRotation)
    {
        StartCoroutine(CoroutineHelper.Lerp(duration, animationCurve, percent =>
        {
            transform.localRotation = Quaternion.Lerp(originalRotation, targetRotation, percent);
        }));
    }

    public void AnimateOpacity(float targetOpacity)
    {
        StartCoroutine(CoroutineHelper.Lerp(duration, animationCurve, percent =>
        {
            var color = GetComponent<Image>().color;
            color.a = Mathf.Lerp(originalOpacity, targetOpacity, percent);
            GetComponent<Image>().color = color;
        }));
    }
}
