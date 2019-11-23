using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;
    [SerializeField] private CountDownManager countDown;

    [SerializeField] private float roundRestartDelay = 2f;

    [SerializeField] private EndgameUi endgameUi;

    public Action OnRoundEnd;

    private void Awake()
    {
        countDown.OnTimesUp += EndTurn;
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

        if (Mathf.Abs(player1.score - player2.score) >= 2)
        {
            EndGame();
            return;
        }

        OnRoundEnd?.Invoke();
        StartCoroutine(StartNewRound());
    }

    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(roundRestartDelay);
        countDown.Restart();
        player1.BeginTurn();
        player2.BeginTurn();
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