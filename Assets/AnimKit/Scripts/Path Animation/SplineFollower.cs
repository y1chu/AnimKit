//----------------------------------------------------------------------------------------
// SplineFollower.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script allows a game object to follow a spline defined by a Spline component.
//    It moves the object along the spline at a specified speed and adjusts its direction
//    based on the spline's control points.
//
// Usage:
//    1. Attach this script to the game object you want to follow the spline.
//    2. Assign the desired Spline component to the spline variable.
//    3. Adjust the speed to control the movement speed along the spline.
//    4. Set the reverse flag to true if you want the follower to move in the opposite direction.
//
// Public Variables:
//    - spline: The Spline component that defines the spline to follow.
//    - speed: The movement speed along the spline.
//    - reverse: Determines whether the follower should move in the opposite direction.
//
// Public Methods:
//    - SetSpeed(float newSpeed): Sets the movement speed to the specified value.
//    - SetReverse(bool newReverse): Sets the reverse flag to the specified value.
//    - SetLoop(bool newLoop): Sets the loop flag of the spline to the specified value.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class SplineFollower : MonoBehaviour
{
    public Spline spline;
    public float speed = 1f;
    public bool reverse = false;
    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * speed * (reverse ? -1 : 1);

        if (spline.loop)
        {
            if (t >= spline.controlPoints.Count) t -= spline.controlPoints.Count;
            else if (t < 0) t += spline.controlPoints.Count;
        }
        else
        {
            t = Mathf.Clamp(t, 0, spline.controlPoints.Count - 1);
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

    // Sets the loop flag of the spline to the specified value
    public void SetLoop(bool newLoop)
    {
        spline.loop = newLoop;
    }
}
