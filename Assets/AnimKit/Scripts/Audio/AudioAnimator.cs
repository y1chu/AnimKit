using UnityEngine;

public class AudioAnimator : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator animator;
    public string animationBool; // The boolean trigger in the Animator to start the animation

    private bool isAnimationTriggered = false;

    void Start()
    {
        if(audioSource.clip == null || animator == null)
        {
            Debug.LogError("Missing Audio Clip or Animator");
            return;
        }
    }

    void Update()
    {
        // When the animation trigger is activated
        if (animator.GetBool(animationBool) && !isAnimationTriggered)
        {
            isAnimationTriggered = true;

            // Start the audio with the animation
            audioSource.time = 0;
            audioSource.Play();
        }

        // When the animation trigger is deactivated
        if (!animator.GetBool(animationBool) && isAnimationTriggered)
        {
            isAnimationTriggered = false;

            // Stop the audio with the animation
            audioSource.Stop();
        }
    }
}