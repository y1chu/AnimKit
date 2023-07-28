using UnityEngine;

public class SpriteAnimationState : MonoBehaviour
{
    public string CurrentState { get; private set; }

    public void SetState(string state)
    {
        CurrentState = state;
    }
}