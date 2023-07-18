//----------------------------------------------------------------------------------------
// UIParticleAnimator.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This script allows you to control the playback of a ParticleSystem component attached to
//    a UI element. It provides methods to play and stop the particle system.
//
// Usage:
//    1. Attach this script to the UI element with the ParticleSystem component.
//    2. Make sure the ParticleSystem component is assigned to the particleSystem variable
//       in the inspector.
//    3. Call the PlayParticles() method to start playing the particle system.
//    4. Call the StopParticles() method to stop the particle system.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class UIParticleAnimator : MonoBehaviour
{
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void PlayParticles()
    {
        particleSystem.Play();
    }

    public void StopParticles()
    {
        particleSystem.Stop();
    }
}