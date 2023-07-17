using UnityEngine;

[CreateAssetMenu(fileName = "ParabolaEasing", menuName = "Easing Functions/Parabola")]
public class ParabolaEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return 4 * (t - 0.5f) * (t - 0.5f);
    }
}