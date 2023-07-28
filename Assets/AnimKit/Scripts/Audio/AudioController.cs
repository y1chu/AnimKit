using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AnimationCurve volumeCurve;
    public AnimationCurve pitchCurve;

    private bool isAudioPlaying = false;

    void Start()
    {
        if(audioSource.clip == null)
        {
            Debug.LogError("Missing Audio Clip");
            return;
        }

        StartCoroutine(ControlAudioParameters());
    }

    IEnumerator ControlAudioParameters()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            // When the audio starts playing
            if (audioSource.isPlaying && !isAudioPlaying)
            {
                isAudioPlaying = true;
            }

            // When the audio is playing
            if (audioSource.isPlaying)
            {
                // Calculate the audio's progress
                float audioProgress = audioSource.time / audioSource.clip.length;

                // Use AnimationCurves to control the audio parameters
                audioSource.volume = volumeCurve.Evaluate(audioProgress);
                audioSource.pitch = pitchCurve.Evaluate(audioProgress);
            }

            // When the audio stops
            if (!audioSource.isPlaying && isAudioPlaying)
            {
                isAudioPlaying = false;
            }
        }
    }
}