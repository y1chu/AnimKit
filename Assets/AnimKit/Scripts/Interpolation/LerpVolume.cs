//----------------------------------------------------------------------------------------
// LerpVolume.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script smoothly interpolates the volume of an AudioSource component from a start
//    volume to an end volume using linear interpolation (lerp). It provides a simple way to
//    create smooth audio volume transitions or animations in Unity.
//
// Usage:
//    1. Attach this script to a game object that has an AudioSource component.
//    2. Adjust the start and end volumes as well as the transition duration in the Unity inspector.
//
// Public Variables:
//    - startVolume: The starting volume of the AudioSource component.
//    - endVolume: The end volume to which the AudioSource component will be interpolated.
//    - transitionDuration: The duration of the transition from the start volume to the end volume.
//
// How it works:
//    - The script retrieves the AudioSource component attached to the game object in the Start() method.
//    - The initial volume is set to the start volume.
//    - The start time of the transition is recorded.
//    - In the Update() method, the script calculates the time elapsed since the start of the transition
//      and divides it by the transition duration to obtain a normalized progress value (t) between 0 and 1.
//    - Linear interpolation (lerp) is then used to calculate the new volume between the start and end
//      volumes based on the progress value.
//    - The AudioSource component's volume is updated to the new interpolated volume.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LerpVolume : MonoBehaviour
{
    // The starting volume of the AudioSource component.
    public float startVolume = 0.0f;

    // The end volume to which the AudioSource component will be interpolated.
    public float endVolume = 1.0f;

    // The duration of the transition from the start volume to the end volume.
    public float transitionDuration = 2.0f;

    private AudioSource audioSource;
    private float transitionStartTime;

    void Start()
    {
        // Retrieve the AudioSource component attached to the game object
        audioSource = GetComponent<AudioSource>();

        // Set the initial volume of the AudioSource component
        audioSource.volume = startVolume;

        // Record the start time of the transition
        transitionStartTime = Time.time;
    }

    void Update()
    {
        // Calculate the progress value (t) based on the time elapsed since the start of the transition
        float t = (Time.time - transitionStartTime) / transitionDuration;

        // Use linear interpolation (lerp) to calculate the new volume between the start and end volumes
        float lerpedVolume = Mathf.Lerp(startVolume, endVolume, t);

        // Update the AudioSource component's volume to the new interpolated volume
        audioSource.volume = lerpedVolume;
    }
}
