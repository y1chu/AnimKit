using UnityEngine;
using System.Collections.Generic;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    public List<EventAnimationTimeline> animationTimelines;
    private Dictionary<EventAnimationTimeline, float> timelineTimes;

    void Start()
    {
        timelineTimes = new Dictionary<EventAnimationTimeline, float>();

        foreach (EventAnimationTimeline animationTimeline in animationTimelines)
        {
            timelineTimes[animationTimeline] = 0f;
        }
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;

        foreach (EventAnimationTimeline animationTimeline in animationTimelines)
        {
            animationTimeline.TriggerEventsInRange(timelineTimes[animationTimeline], timelineTimes[animationTimeline] + deltaTime);
            timelineTimes[animationTimeline] += deltaTime;
        }
    }
}