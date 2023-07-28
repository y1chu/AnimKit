using System.Collections;
using UnityEngine;

public class AudioTimelineSynchronizer : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource to be controlled
    public Animation anim; // Animation to be synchronized with

    private float audioClipLength; // Length of the AudioSource clip
    private float animationClipLength; // Length of the Animation clip

    private bool isAnimationPlaying = false; // State of the Animation

    void Start()
    {
        // Error handling
        if (audioSource.clip == null || anim.clip == null)
        {
            Debug.LogError("Missing Audio or Animation Clip");
            return;
        }

        // Get the lengths of the audio and animation clips
        audioClipLength = audioSource.clip.length;
        animationClipLength = anim.clip.length;

        // Start the Coroutine that syncs the audio with the animation
        StartCoroutine(SyncAudioWithAnimation());
    }

    IEnumerator SyncAudioWithAnimation()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();

            // When the animation starts playing
            if (anim.isPlaying && !isAnimationPlaying)
            {
                isAnimationPlaying = true;
                audioSource.time = 0; // Reset the audio time
                audioSource.Play(); // Play the audio
            }
            
            // When the animation is playing
            if (anim.isPlaying)
            {
                // Calculate the animation's progress
                float animationProgress = anim["animationClip"].time / animationClipLength;
                
                // Sync the audio time with the animation progress
                audioSource.time = animationProgress * audioClipLength;
            }
            
            // When the animation stops
            if (!anim.isPlaying && isAnimationPlaying)
            {
                isAnimationPlaying = false;
                audioSource.Stop(); // Stop the audio
            }
        }
    }
}
