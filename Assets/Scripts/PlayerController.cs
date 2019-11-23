using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Move _selectedMove = Move.None;
    public int score;

    public int playerId;
    private bool Ready => playerId > 0;

    private PlayerController _otherPlayer;
    private PlayerInput _playerInput;
    private bool _actionMapGameSwitch;

    public Action onJoined;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _playerInput = GetComponent<PlayerInput>();
        _otherPlayer = FindObjectsOfType<PlayerController>().First(x => x != this);
    }

    public Move GetMove()
    {
        if (_selectedMove != Move.None) return _selectedMove;
        return (Move) Random.Range((int) Move.Rock, (int) Move.Scissors + 1);
    }

    public void BeginTurn()
    {
        _selectedMove = Move.None;
        Debug.Log("Begin turn");
        if (!_actionMapGameSwitch)
        {
            Debug.Log("Switched to game map");
            _playerInput.SwitchCurrentActionMap("Game");
            _actionMapGameSwitch = true;
        }
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
        if (Ready) return;
        Debug.Log("JOIN");
        playerId = !_otherPlayer.Ready || _otherPlayer.playerId == 2 ? 1 : 2;
        onJoined?.Invoke();
    }

    public void StartGame(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        if (!Ready || !_otherPlayer.Ready)
        {
            Debug.LogWarning("Not all players are ready !");
            return;
        }
        Debug.Log("Start game");
        SceneManager.LoadScene("Game");
    }
}