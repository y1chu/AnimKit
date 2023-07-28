using UnityEngine;

[CreateAssetMenu(fileName = "SpriteAnimationDatabase", menuName = "ScriptableObjects/SpriteAnimationDatabase", order = 1)]
public class SpriteAnimationDatabase : ScriptableObject
{
    public SpriteAnimation[] animations;

    public SpriteAnimation GetAnimation(string name)
    {
        foreach (SpriteAnimation animation in animations)
        {
            if (animation.animationName == name) // renamed from 'name' to 'animationName'
            {
                return animation;
            }
        }

        return null;
    }
}