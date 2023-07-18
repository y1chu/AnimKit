//----------------------------------------------------------------------------------------
// ExampleUIAnimation.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This class provides an example implementation of UI animations using the UILayoutAnimator
//    component and UIAnimationSettings.
//
// Usage:
//    1. Attach this script to a GameObject in the scene that has the UILayoutAnimator component
//       and UIAnimationSettings.
//    2. Assign the UILayoutAnimator and UIAnimationSettings references in the inspector.
//    3. Implement methods to animate different properties of the UI layout using the assigned
//       UILayoutAnimator and UIAnimationSettings.
//
// Public Variables:
//    - layoutAnimator: The UILayoutAnimator component to perform the UI animations.
//    - animationSettings: The UIAnimationSettings component to retrieve animation settings from.
//
// Public Methods:
//    - AnimatePosition(): Animates the position of the UI layout using the assigned UILayoutAnimator
//       and UIAnimationSettings.
//    - AnimateSize(): Animates the size of the UI layout using the assigned UILayoutAnimator
//       and UIAnimationSettings.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

public class ExampleUIAnimation : MonoBehaviour
{
    public UILayoutAnimator layoutAnimator;
    public UIAnimationSettings animationSettings;

    // Animates the position of the UI layout using the assigned UILayoutAnimator and UIAnimationSettings
    public void AnimatePosition()
    {
        UIAnimationSettings.AnimationSettings positionSettings = animationSettings.GetSettingsForType(UIAnimationSettings.AnimationType.Position);
        layoutAnimator.targetPosition = new Vector2(200f, 200f);
        layoutAnimator.duration = positionSettings.duration;
        layoutAnimator.easing = positionSettings.easing;
        layoutAnimator.AnimateLayout();
    }
    
    // Animates the size of the UI layout using the assigned UILayoutAnimator and UIAnimationSettings
    public void AnimateSize()
    {
        UIAnimationSettings.AnimationSettings sizeSettings = animationSettings.GetSettingsForType(UIAnimationSettings.AnimationType.Size);
        layoutAnimator.targetSize = new Vector2(200f, 200f);
        layoutAnimator.duration = sizeSettings.duration;
        layoutAnimator.easing = sizeSettings.easing;
        layoutAnimator.AnimateLayout();
    }

    // More methods could be added here to demonstrate animating other properties
}
