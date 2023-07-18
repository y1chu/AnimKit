//----------------------------------------------------------------------------------------
// UIShapeAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script animates the shape of a UI element by modifying its size over time using
//    an animation curve.
//
// Usage:
//    1. Attach this script to the UI element you want to animate.
//    2. Set the initial size of the UI element in the inspector.
//    3. Set the desired target size for the animation.
//    4. Set the duration of the animation.
//    5. Optionally, adjust the animation curve for different easing effects.
//    6. Call the AnimateShape() method to start the animation.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;

public class UIShapeAnimator : MonoBehaviour
{
    public float duration = 1.0f;
    public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Vector2 originalSize;
    private Vector2 targetSize;

    void Start()
    {
        originalSize = GetComponent<RectTransform>().sizeDelta;
    }

    public void AnimateShape(Vector2 targetShape)
    {
        targetSize = targetShape;
        StartCoroutine(CoroutineHelper.Lerp(duration, animationCurve, percent =>
        {
            GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(originalSize, targetSize, percent);
        }));
    }
}