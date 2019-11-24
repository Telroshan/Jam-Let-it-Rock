using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class DontPressMinigame : MonoBehaviour
{
    public Sprite[] Sprites;
    [SerializeField] private Image Input;
    private GameManager _gameManager;
    private int minigameInput;

    
    private void Awake()
    {
        foreach (PlayerController playerController in FindObjectsOfType<PlayerController>())
        {
            playerController.DontPressMinigame = this;
        }

        _gameManager = FindObjectOfType<GameManager>();
    }
    
    public void getPressedInput(int playerId, Move move)
    {
        if (move.CompareTo((Move) (minigameInput + 1)) != 0) return;
        
        
        if (playerId == 1)
        {
            _gameManager.OnMinigameEnd(false);
        }
        else
        {
            _gameManager.OnMinigameEnd(true);
        }
        gameObject.SetActive(false);
    }
    
    void Start()
    {
        minigameInput = new Random().Next(0, Sprites.Length);
        Input.sprite = Sprites[minigameInput];
    }

    public void StartMinigame()
    {
        gameObject.SetActive(true);
    }
}
