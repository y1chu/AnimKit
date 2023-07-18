//----------------------------------------------------------------------------------------
// UIAnimationSettings.cs
//----------------------------------------------------------------------------------------
//
// Description:
//    This scriptable object holds animation settings for different UI animation types. It allows
//    you to define the duration and easing curve for each animation type, which can be accessed
//    by other scripts to control UI animations.
//
// Usage:
//    1. Create a new scriptable object asset in the project by right-clicking in the Project
//       window, selecting "Create", and then "UI/AnimationSettings".
//    2. Assign the desired animation settings for each animation type in the inspector.
//    3. Use the GetSettingsForType() method to retrieve the animation settings for a specific
//       animation type in other scripts.
//
//----------------------------------------------------------------------------------------
using UnityEngine;

[CreateAssetMenu(menuName = "UI/AnimationSettings")]
public class UIAnimationSettings : ScriptableObject
{
    public enum AnimationType
    {
        Position,
        Size,
        Scale,
        Rotation
    }

    [System.Serializable]
    public struct AnimationSettings
    {
        public AnimationType type;
        public float duration;
        public AnimationCurve easing;
    }

    public AnimationSettings[] settings;

    public AnimationSettings GetSettingsForType(AnimationType type)
    {
        foreach (AnimationSettings setting in settings)
        {
            if (setting.type == type)
                return setting;
        }

        return default;
    }
}