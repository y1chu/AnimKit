using UnityEngine;

[CreateAssetMenu(fileName = "StepEasing", menuName = "Easing Functions/Step")]
public class StepEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return Mathf.Round(t);
    }
}