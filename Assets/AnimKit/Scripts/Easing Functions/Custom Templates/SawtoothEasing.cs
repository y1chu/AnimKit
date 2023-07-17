using UnityEngine;

[CreateAssetMenu(fileName = "SawtoothEasing", menuName = "Easing Functions/Sawtooth")]
public class SawtoothEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return t - Mathf.Floor(t);
    }
}