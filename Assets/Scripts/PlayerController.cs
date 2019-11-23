using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Move _selectedMove = Move.None;
    public int score;

    public int playerId;

    [SerializeField] private PlayerController otherPlayer;

    public Action onJoined;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public Move GetMove()
    {
        if (_selectedMove != Move.None) return _selectedMove;
        return (Move) Random.Range((int) Move.Rock, (int) Move.Scissors + 1);
    }

    public void BeginTurn()
    {
        _selectedMove = Move.None;
    }

    public void Rock(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("ROCK");
        _selectedMove = Move.Rock;
    }

    public void Paper(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("PAPER");
        _selectedMove = Move.Paper;
    }

    public void Scissors(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        Debug.Log("SCISSORS");
        _selectedMove = Move.Scissors;
    }

    public void Join(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        if (playerId > 0) return;
        Debug.Log("JOIN");
        playerId = otherPlayer.playerId == 2 || otherPlayer.playerId == 0 ? 1 : 2;
        onJoined?.Invoke();
    }
}