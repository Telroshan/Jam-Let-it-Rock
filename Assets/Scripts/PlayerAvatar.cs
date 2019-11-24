using System;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite preparedSprite;
    [SerializeField] private Sprite rockSprite;
    [SerializeField] private Sprite paperSprite;
    [SerializeField] private Sprite scissorsSprite;

    private SpriteRenderer _spriteRenderer;

    public enum State
    {
        Idle,
        Prepared,
        Rock,
        Paper,
        Scissors,
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetState(State state)
    {
        switch (state)
        {
            case State.Idle:
                _spriteRenderer.sprite = idleSprite;
                break;
            case State.Prepared:
                _spriteRenderer.sprite = preparedSprite;
                break;
            case State.Rock:
                _spriteRenderer.sprite = rockSprite;
                break;
            case State.Paper:
                _spriteRenderer.sprite = paperSprite;
                break;
            case State.Scissors:
                _spriteRenderer.sprite = scissorsSprite;
                break;
        }
    }
}