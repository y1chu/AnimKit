//----------------------------------------------------------------------------------------
// PathEvent.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script represents a path event in Unity. It provides a UnityEvent that can be
//    triggered when the event is activated.
//
// Usage:
//    1. Attach this script to a game object that represents the path event.
//    2. Assign the desired UnityEvent to the onTrigger variable.
//    3. Call the Trigger() method to invoke the event.
//
// Public Variables:
//    - onTrigger: The UnityEvent that will be triggered when the event is activated.
//
// Public Methods:
//    - Trigger(): Invokes the onTrigger UnityEvent.
//
//----------------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Events;

public class PathEvent : MonoBehaviour
{
    public UnityEvent onTrigger;

    // Invokes the onTrigger UnityEvent
    public void Trigger()
    {
        onTrigger.Invoke();
    }
}