using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EventSystem : MonoBehaviour
{
    private static EventSystem instance;
    private Dictionary<string, UnityEvent> events;

    void Awake()
    {
        // Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            events = new Dictionary<string, UnityEvent>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void RegisterEvent(string eventName, UnityAction callback)
    {
        if (instance.events.ContainsKey(eventName))
        {
            instance.events[eventName].AddListener(callback);
        }
        else
        {
            UnityEvent unityEvent = new UnityEvent();
            unityEvent.AddListener(callback);
            instance.events[eventName] = unityEvent;
        }
    }

    public static void UnregisterEvent(string eventName, UnityAction callback)
    {
        if (instance.events.ContainsKey(eventName))
        {
            instance.events[eventName].RemoveListener(callback);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if (instance.events.ContainsKey(eventName))
        {
            instance.events[eventName]?.Invoke();
        }
    }
}