//----------------------------------------------------------------------------------------
// BezierCurve.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This class represents a cubic Bezier curve in 3D space. It provides methods to calculate
//    points along the curve using interpolation and Lerp operations.
//
// Usage:
//    1. Create a new instance of BezierCurve by providing four Vector3 points.
//    2. Use the GetPoint(float t) method to retrieve a point along the curve at a given t value
//       between 0 and 1.
//
// Public Variables:
//    - points: An array of four Vector3 points that define the cubic Bezier curve.
//
// Public Methods:
//    - BezierCurve(Vector3 point0, Vector3 point1, Vector3 point2, Vector3 point3): Constructor
//      to create a new BezierCurve instance with the specified control points.
//    - GetPoint(float t): Returns a point along the curve at the given t value between 0 and 1.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

[System.Serializable]
public class BezierCurve
{
    public Vector3[] points;

    // Constructor to create a new BezierCurve instance with the specified control points
    public BezierCurve(Vector3 point0, Vector3 point1, Vector3 point2, Vector3 point3)
    {
        points = new Vector3[4];
        points[0] = point0;
        points[1] = point1;
        points[2] = point2;
        points[3] = point3;
    }

    // Returns a point along the curve at the given t value between 0 and 1
    public Vector3 GetPoint(float t)
    {
        return Vector3.Lerp(
            Vector3.Lerp(
                Vector3.Lerp(points[0], points[1], t),
                Vector3.Lerp(points[1], points[2], t),
                t),
            Vector3.Lerp(
                Vector3.Lerp(points[1], points[2], t),
                Vector3.Lerp(points[2], points[3], t),
                t),
            t);
    }
}
