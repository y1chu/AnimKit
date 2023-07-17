using UnityEngine;

[CreateAssetMenu(fileName = "HeartbeatEasing", menuName = "Easing Functions/Heartbeat")]
public class HeartbeatEasing : CustomEasingFunction
{
    public override float Evaluate(float t)
    {
        return Mathf.Sin(2 * Mathf.PI * (t * 2 - 0.5f)) * Mathf.Sin(2 * Mathf.PI * t);
    }
}