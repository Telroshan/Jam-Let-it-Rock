using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndgameUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private GameObject player1VictoryScreen;
    [SerializeField] private GameObject player2VictoryScreen;
    private void Start()
    {
        if (WinnerStatic.player1Won)
        {
            player1VictoryScreen.SetActive(true);
        }
        else
        {
            player2VictoryScreen.SetActive(true);
        }
    }

    public void GoToMainMenu()
    {
        foreach (PlayerController playerController in FindObjectsOfType<PlayerController>())
        {
            Destroy(playerController.gameObject);
        }
        SceneManager.LoadScene(0);
    }
}