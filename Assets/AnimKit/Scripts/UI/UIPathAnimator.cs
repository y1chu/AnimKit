//----------------------------------------------------------------------------------------
// UIPathAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script animates a UI element along a defined path of waypoints. It moves the UI
//    element from one waypoint to another with a specified speed and delay.
//
// Usage:
//    1. Attach this script to the UI element you want to animate.
//    2. Create an empty GameObject and position it as the first waypoint in the scene.
//    3. Create additional empty GameObjects as waypoints and position them along the desired
//       path for the UI element.
//    4. Assign the waypoints to the "waypoints" array in the inspector, starting from the
//       first waypoint and ending with the last waypoint.
//    5. Set the desired speed and delay in the inspector.
//    6. Optionally, enable or disable looping of the path animation.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPathAnimator : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float delay = 0.5f;
    public bool loop = true;
    private IEnumerator<Transform> pointInPath;

    void Start()
    {
        if (waypoints == null || waypoints.Length < 2) 
        {
            Debug.LogError("Insufficient waypoints defined.");
            return;
        }

        pointInPath = GetNextWaypoint();
        pointInPath.MoveNext();

        if (pointInPath.Current == null) 
            return;
        
        transform.position = pointInPath.Current.position;
    }

    void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
            return;

        if (TypeOfPath() == false)
        {
            StartCoroutine("WaitForSeconds", delay);
        }
        else
        {
            StartCoroutine(pointInPath);
        }
    }

    IEnumerator<Transform> GetNextWaypoint()
    {
        while (true)
        {
            foreach (Transform waypoint in waypoints)
            {
                yield return waypoint;
            }

            if (!loop) 
                yield break;
        }
    }

    private bool TypeOfPath()
    {
        var distance = (transform.position - pointInPath.Current.position).magnitude;
        if (distance < speed * Time.deltaTime)
        {
            transform.position = pointInPath.Current.position;
            pointInPath.MoveNext();
            return false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, speed * Time.deltaTime);
            return true;
        }
    }
}
