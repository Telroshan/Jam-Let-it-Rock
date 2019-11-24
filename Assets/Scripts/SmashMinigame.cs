using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class SmashMinigame : MonoBehaviour
{
    public Sprite[] Sprites;
    public Material[] Materials;

    [SerializeField] private Image Player1Input;
    [SerializeField] private Image Player2Input;
    [SerializeField] private Image Cursor;
    [SerializeField] private Image ProgressBarBackground;
    [SerializeField] private ParticleSystem Player1ParticleSystem;
    [SerializeField] private ParticleSystem Player2ParticleSystem;

    private GameManager _gameManager;

    public int GapNeededToWinInInputs = 10;

    private int countOfButtons; // If -GapNeededToWinInInputs Player 2 wins, and +GapNeededToWinInInputs Player 1 wins

    private int minigameInput;

    private void Awake()
    {
        foreach (PlayerController playerController in FindObjectsOfType<PlayerController>())
        {
            playerController.SmashMinigame = this;
        }

        _gameManager = FindObjectOfType<GameManager>();
    }

    public void getPressedInput(int playerId, Move move)
    {
        if (move.CompareTo((Move) (minigameInput + 1)) != 0) return;
        
        Debug.Log("Move chosen : " + Convert.ToInt32( move));
        
        if (playerId == 1)
        {
            Player1ParticleSystem.GetComponent<Renderer>().material = Materials[Convert.ToInt32( move) - 1];
            SetCursor(countOfButtons + 1);
            Player1ParticleSystem.Emit(1);
        }
        else
        {
            Player2ParticleSystem.GetComponent<Renderer>().material = Materials[Convert.ToInt32( move) - 1];
            SetCursor(countOfButtons - 1);
            Player2ParticleSystem.Emit(1);
        }

        if (Mathf.Abs(countOfButtons) >= GapNeededToWinInInputs)
        {
            _gameManager.OnMinigameSmashEnd(countOfButtons > 0);
            gameObject.SetActive(false);
        }
    }

    private void SetCursor(int value)
    {
        countOfButtons = value;
        Cursor.transform.localPosition =
            new Vector3(
                countOfButtons * ProgressBarBackground.GetComponent<RectTransform>().rect.width / 2 /
                GapNeededToWinInInputs, 0f);
    }

    void Start()
    {
        minigameInput = new Random().Next(0, Sprites.Length);
        Player1Input.sprite = Sprites[minigameInput];
        Player2Input.sprite = Sprites[minigameInput];
    }

    public void StartMinigame()
    {
        SetCursor(0);
        gameObject.SetActive(true);
    }
}