using UnityEngine;

[CreateAssetMenu(fileName = "BounceEasing", menuName = "Easing Functions/Bounce")]
public class BounceEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return Mathf.Abs(Mathf.Sin(6.28f * (t + 1) * (t + 1)) * (1 - t));
    }
}