using UnityEngine;

[CreateAssetMenu(fileName = "SpringEasing", menuName = "Easing Functions/Spring")]
public class SpringEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return 1 - (Mathf.Cos(t * 4.5f * Mathf.PI) * Mathf.Exp(-t * 6f));
    }
}