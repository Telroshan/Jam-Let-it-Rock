using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;
    [SerializeField] private CountDownManager countDown;

    [SerializeField] private float roundRestartDelay = 2f;

    [SerializeField] private EndgameUi endgameUi;

    [SerializeField] private TextMeshProUGUI scorePlayer1;
    [SerializeField] private TextMeshProUGUI scorePlayer2;

    [SerializeField] private SmashMinigame _minigameSmashUi;

    public Action OnRoundEnd;

    private void Start()
    {
        countDown.OnTimesUp += EndTurn;
        player1 = FindObjectsOfType<PlayerController>().First(x => x.playerId == 1);
        player2 = FindObjectsOfType<PlayerController>().First(x => x.playerId == 2);
        player1.BeginTurn();
        player2.BeginTurn();
    }

    private void EndTurn()
    {
        Move move1 = player1.GetMove();
        Move move2 = player2.GetMove();

        Debug.Log("Player 1 plays " + move1 + " | Player 2 plays " + move2);

        if (move1 == move2)
        {
            Debug.Log("Draw");
        }
        else if (move1 == Move.Paper && move2 == Move.Rock ||
                 move1 == Move.Rock && move2 == Move.Scissors ||
                 move1 == Move.Scissors && move2 == Move.Paper)
        {
            ++player1.score;
        }
        else
        {
            ++player2.score;
        }

        UpdateScore();

        if (Mathf.Abs(player1.score - player2.score) >= 2)
        {
            StartMinigameSmash();
//            EndGame();
            return;
        }

        OnRoundEnd?.Invoke();
        StartCoroutine(StartNewRound());
    }

    private void UpdateScore()
    {
        scorePlayer1.text = player1.score.ToString();
        scorePlayer2.text = player2.score.ToString();
    }

    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(roundRestartDelay);
        countDown.Restart();
        player1.BeginTurn();
        player2.BeginTurn();
    }

    private void StartMinigameSmash()
    {
        player1.gameMode = PlayerController.GameMode.SmashMinigame;
        player2.gameMode = PlayerController.GameMode.SmashMinigame;
        _minigameSmashUi.StartMinigame();
    }

    public void OnMinigameSmashEnd(bool player1Won)
    {
        if (player1Won && player1.score >= player2.score + 2 ||
            !player1Won && player2.score >= player1.score + 2)
        {
            EndGame();
        }
        else
        {
            if (player1.score < player2.score) ++player1.score;
            else if (player2.score < player1.score) ++player2.score;
            UpdateScore();
            StartCoroutine(StartNewRound());
        }
    }

    private void EndGame()
    {
        if (player1.score > player2.score)
        {
            Debug.Log("Player 1 wins");
            endgameUi.Init("Player 1");
        }
        else
        {
            Debug.Log("Player 2 wins");
            endgameUi.Init("Player 2");
        }
    }
}