//----------------------------------------------------------------------------------------
// PathDefinition.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script defines a path for object movement in Unity. It stores a list of points
//    as transforms and provides an enumerator to iterate through the points in a continuous
//    loop, allowing for smooth movement along the defined path.
//
// Usage:
//    1. Attach this script to a game object that represents the path.
//    2. Populate the Points list with the desired transform points.
//    3. Use the GetPathEnumerator() method to retrieve an enumerator for iterating through
//       the points in the path.
//
// Public Variables:
//    - Points: A list of transform points that define the path.
//
// Public Methods:
//    - GetPathEnumerator(): Returns an enumerator to iterate through the points in the path.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using System.Collections.Generic;

public class PathDefinition : MonoBehaviour
{
    public List<Transform> Points = new List<Transform>();

    // Returns an enumerator to iterate through the points in the path
    public IEnumerator<Transform> GetPathEnumerator()
    {
        if (Points == null || Points.Count < 1)
            yield break;

        int direction = 1;
        int index = 0;

        while (true)
        {
            yield return Points[index];

            if (Points.Count == 1)
                continue;

            if (index <= 0)
                direction = 1;
            else if (index >= Points.Count - 1)
                direction = -1;

            index = index + direction;
        }
    }
}