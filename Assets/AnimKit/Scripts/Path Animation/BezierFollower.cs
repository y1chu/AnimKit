//----------------------------------------------------------------------------------------
// BezierFollower.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script allows a game object to follow a BezierCurve by interpolating its position
//    along the curve. It provides options for controlling the speed, looping, reversing, and
//    event triggering based on proximity to path events.
//
// Usage:
//    1. Attach this script to the game object you want to follow the BezierCurve.
//    2. Assign the BezierCurve you want to follow to the curve variable.
//    3. Adjust the speed to control the movement speed along the curve.
//    4. Set the loop flag to true if you want the follower to loop around the curve indefinitely.
//    5. Set the reverse flag to true if you want the follower to move in the opposite direction.
//    6. Set the linear flag to true if you want the follower to move linearly between the first
//       and last points of the curve instead of following the curve shape.
//    7. Set the eventTriggerDistance to control the proximity at which path events are triggered.
//
// Public Variables:
//    - curve: The BezierCurve to follow.
//    - speed: The movement speed along the curve.
//    - loop: Determines whether the follower should loop around the curve.
//    - reverse: Determines whether the follower should move in the opposite direction.
//    - linear: Determines whether the follower should move linearly between the first and last
//      points of the curve.
//    - eventTriggerDistance: The proximity at which path events are triggered.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class BezierFollower : MonoBehaviour
{
    public BezierCurve curve;
    public float speed = 1f;
    public bool loop = false;
    public bool reverse = false;
    public bool linear = false;
    public float eventTriggerDistance = 0.1f;
    private float t = 0;

    void Update()
    {
        t += Time.deltaTime * speed * (reverse ? -1 : 1);

        if (loop)
        {
            if (t > 1f)
            {
                t -= 1f;
            }
            else if (t < 0f)
            {
                t += 1f;
            }
        }
        else
        {
            t = Mathf.Clamp01(t);
        }

        Vector3 position;
        if (linear)
        {
            // Linear interpolation between the first and last points
            position = Vector3.Lerp(curve.points[0], curve.points[curve.points.Length - 1], t);
        }
        else
        {
            // Bezier curve interpolation
            position = curve.GetPoint(t);
        }

        transform.position = position;

        // Check for nearby path events and trigger them
        PathEvent[] pathEvents = FindObjectsOfType<PathEvent>();
        foreach (PathEvent pathEvent in pathEvents)
        {
            if (Vector3.Distance(position, pathEvent.transform.position) <= eventTriggerDistance)
            {
                pathEvent.Trigger();
            }
        }
    }
}
