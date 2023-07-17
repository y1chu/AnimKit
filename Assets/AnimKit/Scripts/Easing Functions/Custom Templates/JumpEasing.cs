using UnityEngine;

[CreateAssetMenu(fileName = "JumpEasing", menuName = "Easing Functions/Jump")]
public class JumpEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return Mathf.Abs(Mathf.Sin(2 * Mathf.PI * t)) < 0.5f ? 0f : 1f;
    }
}