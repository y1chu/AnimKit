using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AnimationEvent", menuName = "AnimKit/AnimationEvent", order = 1)]
public class AnimationEvent : ScriptableObject
{
    [SerializeField]
    public string eventName;
    [SerializeField]
    public UnityEvent unityEvent;
    [SerializeField]
    public float time;

    public void InvokeEvent()
    {
        unityEvent?.Invoke();
    }
}