using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndgameUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    private void Start()
    {
        winText.text = WinnerStatic.WinnerText + " wins";
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