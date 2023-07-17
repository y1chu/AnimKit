using UnityEngine;

[CreateAssetMenu(fileName = "JitterEasing", menuName = "Easing Functions/Jitter")]
public class JitterEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return t + (Mathf.PerlinNoise(t * 10f, t * 10f) - 0.5f) / 10f;
    }
}