using UnityEngine;

public class SpriteEffects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) Debug.LogError("SpriteRenderer component missing.");
    }

    public void FlipSprite(bool flipX, bool flipY)
    {
        spriteRenderer.flipX = flipX;
        spriteRenderer.flipY = flipY;
    }

    public void RotateSprite(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}