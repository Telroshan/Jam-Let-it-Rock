using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;
    [SerializeField] private CountDownManager countDown;

    private void Awake()
    {
        countDown.OnTimesUp += EndTurn;
    }

    private void EndTurn()
    {
        Move move1 = player1.GetMove();
        Move move2 = player2.GetMove();

        Debug.Log("Player 1 plays " + move1 + " | Player 2 plays " + move2);

        // TODO : win condition check
        // TODO : increment score

        if (Mathf.Abs(player1.score - player2.score) >= 2)
        {
            if (player1.score > player2.score)
            {
                Debug.Log("Player 1 wins");
            }
            else
            {
                Debug.Log("Player 2 wins");
            }

            return;
        }
        
        countDown.Restart();
    }
}