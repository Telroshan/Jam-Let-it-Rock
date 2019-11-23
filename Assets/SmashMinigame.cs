using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.UI;
using Random = System.Random;

public class SmashMinigame : MonoBehaviour
{
    public Sprite[] Sprites;

    [SerializeField] private Image Player1Input;
    [SerializeField] private Image Player2Input;
    [SerializeField] private Image Cursor;
    [SerializeField] private Image ProgressBarBackground;
    [SerializeField] private ParticleSystem Player1ParticleSystem;
    [SerializeField] private ParticleSystem Player2ParticleSystem;

    public int GapNeededToWinInInputs = 10;

    private int countOfButtons = 0; // If -50 Player 1 Lose, and +50 Player 1 win

    private int minigameInput;

    private void Awake()
    {
        foreach (PlayerController playerController in FindObjectsOfType<PlayerController>())
        {
            playerController.SmashMinigame = this;
        }
    }

    public void getPressedInput(int playerId, Move move)
    {
        if (move.CompareTo((Move) (minigameInput + 1)) != 0) return;

        if (playerId == 1)
        {
            countOfButtons += 1;
            MoveCursor(1);
            Player1ParticleSystem.Emit(1);
        }
        else
        {
            countOfButtons -= 1;
            MoveCursor(-1);
            Player2ParticleSystem.Emit(1);
        }
    }

    private void MoveCursor(int direction)
    {
        float moveUnit = (ProgressBarBackground.GetComponent<RectTransform>().rect.width / 2) / GapNeededToWinInInputs;
        Cursor.transform.position += new Vector3(direction * moveUnit, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        minigameInput = new Random().Next(0, Sprites.Length);
        Player1Input.sprite = Sprites[minigameInput];
        Player2Input.sprite = Sprites[minigameInput];
    }

    // Update is called once per frame
    void Update()
    {
    }
}