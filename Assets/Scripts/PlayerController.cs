using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private Move _selectedMove = Move.None;
    public int score;

    public int playerId;
    private bool Ready => playerId > 0;

    private PlayerController _otherPlayer;
    private PlayerInput _playerInput;
    public GameMode gameMode = GameMode.Menu;

    public SmashMinigame SmashMinigame { get; set; }

    public enum GameMode
    {
        Menu,
        InGame,
        SmashMinigame,
        DontPressMinigame,
    }

    public Action<PlayerController> onJoined;
    public Action<PlayerController> onDisconnected;

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
        if (gameMode == GameMode.Menu)
        {
            Debug.Log("Switched to game map");
            _playerInput.SwitchCurrentActionMap("Game");
            _playerInput.uiInputModule = null;
        }

        gameMode = GameMode.InGame;
    }

    public void Rock(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        switch (gameMode)
        {
            case GameMode.InGame:
                Debug.Log("ROCK");
                _selectedMove = Move.Rock;
                break;
            case GameMode.SmashMinigame:
                SmashMinigame.getPressedInput(playerId, Move.Rock);
                break;
        }
    }

    public void Paper(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        switch (gameMode)
        {
            case GameMode.InGame:
                Debug.Log("PAPER");
                _selectedMove = Move.Paper;
                break;
            case GameMode.SmashMinigame:
                SmashMinigame.getPressedInput(playerId, Move.Paper);
                break;
        }
    }

    public void Scissors(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        switch (gameMode)
        {
            case GameMode.InGame:
                Debug.Log("SCISSORS");
                _selectedMove = Move.Scissors;
                break;
            case GameMode.SmashMinigame:
                SmashMinigame.getPressedInput(playerId, Move.Scissors);
                break;
        }
    }

    public void Join(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        if (Ready) return;
        Debug.Log("JOIN");
        playerId = !_otherPlayer.Ready || _otherPlayer.playerId == 2 ? 1 : 2;
        if (playerId == 1 && !_playerInput.uiInputModule)
        {
            _playerInput.uiInputModule = _otherPlayer._playerInput.uiInputModule
                ? _otherPlayer._playerInput.uiInputModule
                : FindObjectOfType<InputSystemUIInputModule>();
            _otherPlayer._playerInput.uiInputModule = null;
            _playerInput.uiInputModule.actionsAsset = _playerInput.actions;
            _playerInput.uiInputModule.UpdateModule();
        }

        onJoined?.Invoke(this);
    }

    public void Disconnected()
    {
        onDisconnected?.Invoke(this);
        if (gameMode == GameMode.Menu)
        {
            playerId = 0;
        }
    }
}