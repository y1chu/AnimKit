using UnityEngine;

[CreateAssetMenu(fileName = "AnimationClipData", menuName = "AnimKit/AnimationClipData", order = 1)]
public class AnimationClipData : ScriptableObject
{
    public string name; // The name of the animation
    public AnimationClip clip; // The AnimationClip object
    public float startTime; // When the animation should start in seconds
    public float duration; // The duration of the animation in seconds
    public bool loop; // If the animation should loop or not

    // Constructor
    public AnimationClipData(string name, AnimationClip clip, float startTime, float duration, bool loop)
    {
        this.name = name;
        this.clip = clip;
        this.startTime = startTime;
        this.duration = duration;
        this.loop = loop;
    }
    
    public void Init(string id, AnimationClip animation, float startTime, float duration, bool isLooping)
    {
        this.name = id;
        this.clip = animation;
        this.startTime = startTime;
        this.duration = duration;
        this.loop = isLooping;
    }
    
}