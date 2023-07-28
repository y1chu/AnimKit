using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AnimationTimeline", menuName = "AnimKit/AnimationTimeline", order = 1)]
public class EventAnimationTimeline : ScriptableObject
{
    [SerializeField]
    public List<AnimationEvent> animationEvents;

    public void TriggerEventsInRange(float startTime, float endTime)
    {
        foreach (AnimationEvent animationEvent in animationEvents)
        {
            if (animationEvent.time >= startTime && animationEvent.time <= endTime)
            {
                animationEvent.InvokeEvent();
            }
        }
    }
}