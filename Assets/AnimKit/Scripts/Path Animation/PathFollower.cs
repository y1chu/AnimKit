//----------------------------------------------------------------------------------------
// PathFollower.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script allows a game object to follow a path defined by a PathDefinition component.
//    It moves the object along the path at a specified speed and adjusts its rotation to face
//    the direction of movement.
//
// Usage:
//    1. Attach this script to the game object you want to follow the path.
//    2. Assign the desired PathDefinition component to the Path variable.
//    3. Adjust the Speed variable to control the movement speed.
//    4. Set the MaxDistanceToGoal variable to specify the maximum distance to a path point
//       for it to be considered reached.
//
// Public Variables:
//    - Path: The PathDefinition component that defines the path to follow.
//    - Speed: The movement speed along the path.
//    - MaxDistanceToGoal: The maximum distance to a path point for it to be considered reached.
//
// Private Variables:
//    - currentPoint: An IEnumerator used to iterate through the path points.
//
// Public Methods:
//    - Start(): Initializes the path following by setting the initial position.
//    - Update(): Updates the object's position and rotation to follow the path.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFollower : MonoBehaviour
{
    public PathDefinition Path;
    public float Speed = 5f;
    public float MaxDistanceToGoal = 0.1f;

    private IEnumerator<Transform> currentPoint;

    // Initializes the path following by setting the initial position
    void Start()
    {
        if (Path == null)
        {
            Debug.LogError("Path cannot be null", gameObject);
            return;
        }

        currentPoint = Path.GetPathEnumerator();
        currentPoint.MoveNext();

        if (currentPoint.Current == null)
            return;

        transform.position = currentPoint.Current.position;
    }

    // Updates the object's position and rotation to follow the path
    void Update()
    {
        if (currentPoint == null || currentPoint.Current == null)
            return;

        if (Vector3.Distance(transform.position, currentPoint.Current.position) < MaxDistanceToGoal)
            currentPoint.MoveNext();

        Vector3 direction = currentPoint.Current.position - transform.position;
        Vector3 velocity = direction.normalized * Speed * Time.deltaTime;

        if (velocity.sqrMagnitude > direction.sqrMagnitude)
            velocity = direction;

        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
