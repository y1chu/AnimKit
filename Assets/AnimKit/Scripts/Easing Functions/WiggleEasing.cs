using UnityEngine;

[CreateAssetMenu(fileName = "WiggleEasing", menuName = "Easing Functions/Wiggle")]
public class WiggleEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return ((-Mathf.Cos(2 * Mathf.PI * t) + 1) / 2) + ((-Mathf.Cos(4 * Mathf.PI * t) + 1) / 4);
    }
}