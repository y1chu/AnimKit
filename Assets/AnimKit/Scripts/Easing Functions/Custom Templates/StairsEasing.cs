using UnityEngine;

[CreateAssetMenu(fileName = "StairsEasing", menuName = "Easing Functions/Stairs")]
public class StairsEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return Mathf.Round(t * 5) / 5;
    }
}