using System.Collections;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteAnimationDatabase animationDatabase;
    public SpriteAnimationState animationState;

    private SpriteRenderer spriteRenderer;
    private SpriteAnimation currentAnimation;
    private int currentFrame;
    private float frameTimer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component missing.");
        if (animationDatabase == null) Debug.LogError("SpriteAnimationDatabase missing.");
        if (animationState == null) Debug.LogError("SpriteAnimationState missing.");

        SetAnimation(animationState.CurrentState);
    }

    void Update()
    {
        if (animationState.CurrentState != currentAnimation.name)
        {
            SetAnimation(animationState.CurrentState);
        }

        frameTimer += Time.deltaTime;
        if (frameTimer >= currentAnimation.frameDurations[currentFrame])
        {
            currentFrame++;
            if (currentFrame >= currentAnimation.sprites.Length)
            {
                currentFrame = currentAnimation.loop ? 0 : currentAnimation.sprites.Length - 1;
            }

            spriteRenderer.sprite = currentAnimation.sprites[currentFrame];
            frameTimer = 0f;
        }
    }

    void SetAnimation(string animationName)
    {
        currentAnimation = animationDatabase.GetAnimation(animationName);
        if (currentAnimation == null) Debug.LogError("Animation " + animationName + " not found.");

        currentFrame = 0;
        spriteRenderer.sprite = currentAnimation.sprites[currentFrame];
    }
}