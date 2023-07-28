using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TimelineData", menuName = "AnimKit/TimelineData", order = 1)]
public class TimelineData : ScriptableObject
{
    public List<AnimationClipData> animations = new List<AnimationClipData>();
    public float duration;
    public bool loop;

    public void AddAnimationClipData(AnimationClipData animationClipData)
    {
        animations.Add(animationClipData);
        CalculateDuration();
    }

    public void RemoveAnimationClipData(AnimationClipData animationClipData)
    {
        animations.Remove(animationClipData);
        CalculateDuration();
    }

    public void RemoveAnimationClipDataById(string id)
    {
        var animation = animations.FirstOrDefault(a => a.name == id);
        if (animation != null)
        {
            animations.Remove(animation);
            CalculateDuration();
        }
    }

    public AnimationClipData GetAnimationClipDataById(string id)
    {
        return animations.FirstOrDefault(a => a.name == id);
    }

    public void ClearAnimations()
    {
        animations.Clear();
        CalculateDuration();
    }

    private void CalculateDuration()
    {
        duration = 0;
        foreach (var animation in animations)
        {
            var animationEnd = animation.startTime + animation.duration;
            if (animationEnd > duration)
            {
                duration = animationEnd;
            }
        }
    }
}