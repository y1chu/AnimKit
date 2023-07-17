//----------------------------------------------------------------------------------------
// BezierSpline.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This class represents a Bezier spline in 3D space. It stores a list of control points
//    as Vector3 and provides a method to calculate points along the spline using interpolation.
//
// Usage:
//    1. Create a new instance of BezierSpline.
//    2. Populate the controlPoints list with the desired Vector3 control points.
//    3. Use the GetPoint(float t) method to retrieve a point along the spline at a given t
//       value between 0 and 1.
//
// Public Variables:
//    - controlPoints: A list of Vector3 control points that define the Bezier spline.
//
// Public Methods:
//    - GetPoint(float t): Returns a point along the spline at the given t value between 0 and 1.
//
//----------------------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

public class BezierSpline
{
    public List<Vector3> controlPoints = new List<Vector3>();

    // Returns a point along the spline at the given t value between 0 and 1
    public Vector3 GetPoint(float t)
    {
        int segmentIndex = (int)(t * (controlPoints.Count - 1) / 2);
        Vector3 p0 = controlPoints[segmentIndex * 2];
        Vector3 p1 = controlPoints[segmentIndex * 2 + 1];
        Vector3 p2 = controlPoints[(segmentIndex + 1) * 2];

        t = t * (controlPoints.Count - 1) / 2 - segmentIndex;

        return (1 - t) * (1 - t) * p0 + 2 * (1 - t) * t * p1 + t * t * p2;
    }
}