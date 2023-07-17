//----------------------------------------------------------------------------------------
// LerpPosition.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script smoothly interpolates the position of a game object from a start position
//    to an end position using linear interpolation (lerp). It provides a simple way to create
//    smooth transitions or animations in Unity.
//
// Usage:
//    1. Attach this script to a game object that you want to animate.
//    2. Adjust the start and end positions as well as the transition speed in the Unity inspector.
//
// Public Variables:
//    - startPosition: The starting position of the game object.
//    - endPosition: The end position to which the game object will be interpolated.
//    - transitionSpeed: The speed of the transition from the start position to the end position.
//
// How it works:
//    - The script sets the game object's position to the start position in the Start() method.
//    - The current time is recorded.
//    - In the Update() method, the script calculates the time elapsed since the start of the
//      transition and uses it to interpolate a new position between the start and end positions
//      using Vector3.Lerp().
//    - The game object's position is then updated to the new interpolated position.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class LerpPosition : MonoBehaviour
{
    // The starting position of the game object.
    public Vector3 startPosition;

    // The end position to which the game object will be interpolated.
    public Vector3 endPosition;

    // The speed of the transition from the start position to the end position.
    public float transitionSpeed = 1.0f;

    private float startTime;

    void Start()
    {
        // Set the start position of the game object.
        transform.position = startPosition;

        // Record the start time.
        startTime = Time.time;
    }

    void Update()
    {
        // Calculate the time elapsed since the start of the transition.
        float t = (Time.time - startTime) * transitionSpeed;

        // Use linear interpolation (lerp) to calculate the new position.
        transform.position = Vector3.Lerp(startPosition, endPosition, t);
    }
}
