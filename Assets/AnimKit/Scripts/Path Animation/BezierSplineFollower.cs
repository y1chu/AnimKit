//----------------------------------------------------------------------------------------
// BezierSplineFollower.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script allows a game object to follow a BezierSpline by interpolating its position
//    along the spline. It provides options for controlling the speed and direction of movement.
//
// Usage:
//    1. Attach this script to the game object you want to follow the BezierSpline.
//    2. Assign the BezierSpline you want to follow to the spline variable.
//    3. Adjust the speed to control the movement speed along the spline.
//    4. Set the reverse flag to true if you want the follower to move in the opposite direction.
//
// Public Variables:
//    - spline: The BezierSpline to follow.
//    - speed: The movement speed along the spline.
//    - reverse: Determines whether the follower should move in the opposite direction.
//
// Public Methods:
//    - SetSpeed(float newSpeed): Sets the movement speed to the specified value.
//    - SetReverse(bool newReverse): Sets the reverse flag to the specified value.
//
//----------------------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

public class BezierSplineFollower : MonoBehaviour
{
    public BezierSpline spline;
    public float speed = 1f;
    public bool reverse = false;
    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * speed * (reverse ? -1 : 1);

        if (t >= 1f)
        {
            t -= 1f;
        }
        else if (t < 0f)
        {
            t += 1f;
        }

        transform.position = spline.GetPoint(t);
    }

    // Sets the movement speed to the specified value
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Sets the reverse flag to the specified value
    public void SetReverse(bool newReverse)
    {
        reverse = newReverse;
    }
}
