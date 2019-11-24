using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndgameUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        winText.text = WinnerStatic.WinnerText + " wins";
        restartButton.Select();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}