using System;
using System.Collections;
using UnityEngine;

public class IngameUi : MonoBehaviour
{
    [SerializeField] private Animator playerOneInputs;
    [SerializeField] private Animator playerTwoInputs;
    [SerializeField] private Animator preparationOverlay;
    [SerializeField] private CountDownManager countDownManager;

    private static readonly int Game = Animator.StringToHash("StartGame");

    private bool _started;

    private PlayerController[] _playerControllers;

    [SerializeField] private Animator player1Rock;
    [SerializeField] private Animator player1Paper;
    [SerializeField] private Animator player1Scissors;
    [SerializeField] private Animator player2Rock;
    [SerializeField] private Animator player2Paper;
    [SerializeField] private Animator player2Scissors;
    private static readonly int Pressed = Animator.StringToHash("Pressed");

    [SerializeField] private GameObject readyButton;

    private void Awake()
    {
        _playerControllers = FindObjectsOfType<PlayerController>();
        foreach (PlayerController playerController in _playerControllers)
        {
            playerController.onMoveSelect += OnMoveSelect;
        }
    }

    private void OnMoveSelect(PlayerController playerController, Move move)
    {
        if (_started) return;

        if (playerController.playerId == 1)
        {
            switch (move)
            {
                case Move.Paper:
                    player1Paper.SetTrigger(Pressed);
                    break;
                case Move.Rock:
                    player1Rock.SetTrigger(Pressed);
                    break;
                case Move.Scissors:
                    player1Scissors.SetTrigger(Pressed);
                    break;
            }
        }
        else
        {
            switch (move)
            {
                case Move.Paper:
                    player2Paper.SetTrigger(Pressed);
                    break;
                case Move.Rock:
                    player2Rock.SetTrigger(Pressed);
                    break;
                case Move.Scissors:
                    player2Scissors.SetTrigger(Pressed);
                    break;
            }
        }
    }

    public void StartGame(Action endAnimationCallback)
    {
        StartCoroutine(StartGameCoroutine(endAnimationCallback));
    }

    private IEnumerator StartGameCoroutine(Action endAnimationCallback)
    {
        _started = true;

        foreach (PlayerController playerController in _playerControllers)
        {
            playerController.onMoveSelect -= OnMoveSelect;
        }

        playerOneInputs.SetTrigger(Game);
        playerTwoInputs.SetTrigger(Game);
        preparationOverlay.SetTrigger(Game);
        readyButton.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        countDownManager.gameObject.SetActive(true);
        endAnimationCallback?.Invoke();
    }
}