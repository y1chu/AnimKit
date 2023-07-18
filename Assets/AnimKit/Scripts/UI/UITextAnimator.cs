//----------------------------------------------------------------------------------------
// UITextAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script animates the appearance of text by gradually typing out the characters
//    with a specified delay and color transition.
//
// Usage:
//    1. Attach this script to a GameObject with a Text component.
//    2. Set the desired delay between each character being typed out.
//    3. Set the start and end color for the text animation.
//    4. Call the AnimateText() method and pass the desired text message to start the animation.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class UITextAnimator : MonoBehaviour
{
    private Text textComponent;

    public float delay = 0.1f;
    public Color startColor = Color.black;
    public Color endColor = Color.white;

    void Awake()
    {
        textComponent = GetComponent<Text>();
    }

    public void AnimateText(string message)
    {
        StartCoroutine(TypeText(message));
    }

    IEnumerator TypeText(string message)
    {
        textComponent.text = "";
        textComponent.color = startColor;

        foreach (char letter in message.ToCharArray())
        {
            textComponent.text += letter;

            if (textComponent.color != endColor)
                textComponent.color = Color.Lerp(textComponent.color, endColor, delay);

            yield return new WaitForSeconds(delay);
        }
    }
}