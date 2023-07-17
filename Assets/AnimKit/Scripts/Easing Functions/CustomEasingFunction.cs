using UnityEngine;

public abstract class CustomEasingFunction : ScriptableObject
{
    public abstract float Evaluate(float time);
}