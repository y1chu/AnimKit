//----------------------------------------------------------------------------------------
// AnimationTimeline.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script manages a timeline of events that can be triggered based on their specified
//    event time. It allows you to associate MonoBehaviour scripts and methods with specific
//    points in time to create timeline-based animations or sequences of actions.
//
// Usage:
//    1. Attach this script to a GameObject in the scene that you want to control with a timeline.
//    2. Add TimelineEvent objects to the timelineEvents list in the inspector, specifying the
//       event time, event name, target script, and target method for each event.
//    3. Implement the desired methods in the target scripts to be invoked at the specified times.
//
// Notes:
//    - The targetScript must be a MonoBehaviour script attached to a GameObject in the scene.
//    - The targetMethod must be a public method defined in the targetScript.
//
//----------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[Serializable]
public class TimelineEvent
{
    public float eventTime;
    public string eventName;
    public MonoBehaviour targetScript;
    public string targetMethod;
}

public class AnimationTimeline : MonoBehaviour
{
    public List<TimelineEvent> timelineEvents = new List<TimelineEvent>();

    private void Update()
    {
        float currentTime = Time.time;
        foreach (TimelineEvent timelineEvent in timelineEvents)
        {
            if (currentTime >= timelineEvent.eventTime)
            {
                MethodInfo method = timelineEvent.targetScript.GetType().GetMethod(timelineEvent.targetMethod);
                method.Invoke(timelineEvent.targetScript, null);
            }
        }
    }
}