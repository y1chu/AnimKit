using UnityEngine;

[CreateAssetMenu(fileName = "SpriteAnimation", menuName = "ScriptableObjects/SpriteAnimation", order = 1)]
public class SpriteAnimation : ScriptableObject
{
    public string animationName; // renamed from 'name' to 'animationName'
    public Sprite[] sprites;
    public float[] frameDurations;
    public bool loop;
}