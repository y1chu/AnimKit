using UnityEngine;
using System;

public class CustomEasing : MonoBehaviour
{
    // Define a delegate that matches the signature of an easing function
    public delegate float EasingFunction(float t);
    public EasingFunction easingFunction;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public float duration = 1f;

    private float startTime;

    void Start()
    {
        // Default to linear easing if none is provided
        if (easingFunction == null)
        {
            easingFunction = Linear;
        }

        startPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        float t = (Time.time - startTime) / duration;
        t = easingFunction(t); // Apply the custom easing function

        // Interpolate position
        transform.position = Vector3.Lerp(startPosition, endPosition, t);
    }

    // Linear easing function
    float Linear(float t)
    {
        return t;
    }
}