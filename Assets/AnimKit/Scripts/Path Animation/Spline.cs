//----------------------------------------------------------------------------------------
// Spline.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This class represents a spline curve in 3D space. It stores a list of control points
//    as Vector3 and provides a method to calculate points along the spline using interpolation.
//
// Usage:
//    1. Create a new instance of Spline.
//    2. Populate the controlPoints list with the desired Vector3 control points.
//    3. Use the GetPoint(float t) method to retrieve a point along the spline at a given t
//       value between 0 and 1.
//
// Public Variables:
//    - controlPoints: A list of Vector3 control points that define the spline curve.
//    - loop: Determines whether the spline is a closed loop.
//
// Public Methods:
//    - GetPoint(float t): Returns a point along the spline at the given t value between 0 and 1.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;

public class Spline
{
    public List<Vector3> controlPoints = new List<Vector3>();

    public Vector3 GetPoint(float t)
    {
        int p0, p1, p2, p3;
        if (!loop)
        {
            p1 = (int)t + 1;
            p2 = p1 + 1;
            p3 = p2 + 1;
            p0 = p1 - 1;
        }
        else
        {
            p1 = (int)t;
            p2 = (p1 + 1) % controlPoints.Count;
            p3 = (p2 + 1) % controlPoints.Count;
            p0 = p1 >= 1 ? p1 - 1 : controlPoints.Count - 1;
        }

        t -= (int)t;

        float tt = t * t;
        float ttt = tt * t;

        float q1 = -ttt + 2.0f * tt - t;
        float q2 = 3.0f * ttt - 5.0f * tt + 2.0f;
        float q3 = -3.0f * ttt + 4.0f * tt + t;
        float q4 = ttt - tt;

        return 0.5f * (controlPoints[p0] * q1 + controlPoints[p1] * q2 + controlPoints[p2] * q3 + controlPoints[p3] * q4);
    }

    public bool loop = false;
}
