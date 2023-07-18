//----------------------------------------------------------------------------------------
// UIInteractiveAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script provides interactive animations for UI elements based on pointer events,
//    such as click, hover, and drag. It allows you to specify different scales for each event
//    and animates the scale of the UI element accordingly. The animations use lerping over a
//    specified duration.
//
// Usage:
//    1. Attach this script to the UI element you want to animate.
//    2. Set the click scale, hover scale, and duration in the inspector.
//    3. Implement the necessary interface methods to handle pointer events.
//
//    Note: Make sure the UI element has the required components (e.g., RectTransform) for the
//    corresponding animations.
//
//----------------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInteractiveAnimator : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    public Vector3 clickScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);
    public float duration = 0.2f;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(LerpScale(clickScale, duration));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(LerpScale(hoverScale, duration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(LerpScale(originalScale, duration));
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    private IEnumerator LerpScale(Vector3 targetScale, float duration)
    {
        float time = 0;
        Vector3 initialScale = transform.localScale;

        while (time < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
