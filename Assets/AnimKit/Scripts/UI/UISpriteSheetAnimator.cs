//----------------------------------------------------------------------------------------
// UISpriteSheetAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script animates a sprite sheet by cycling through the sprites at a specified frame rate.
//
// Usage:
//    1. Attach this script to a GameObject with an Image component.
//    2. Assign the sprite sheet frames to the 'sprites' array in the inspector.
//    3. Set the desired frame rate for the animation.
//    4. The script will automatically start playing the sprite sheet on Start().
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class UISpriteSheetAnimator : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameRate = 0.1f;

    private Image imageComponent;
    private int currentFrame;

    void Awake()
    {
        imageComponent = GetComponent<Image>();
        currentFrame = 0;
    }

    void Start()
    {
        if (sprites.Length > 0)
        {
            StartCoroutine(PlaySpriteSheet());
        }
    }

    IEnumerator PlaySpriteSheet()
    {
        while (true)
        {
            yield return new WaitForSeconds(frameRate);
            currentFrame = (currentFrame + 1) % sprites.Length;
            imageComponent.sprite = sprites[currentFrame];
        }
    }
}