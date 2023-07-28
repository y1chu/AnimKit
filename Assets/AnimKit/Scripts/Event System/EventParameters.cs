using UnityEngine;

[CreateAssetMenu(fileName = "EventParameters", menuName = "AnimKit/EventParameters", order = 1)]
public class EventParameters : ScriptableObject
{
    [SerializeField]
    public string eventName;
    [SerializeField]
    public object[] parameters;
}