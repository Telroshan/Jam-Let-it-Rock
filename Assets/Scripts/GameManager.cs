using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController _player1;
    private PlayerController _player2;
    [SerializeField] private CountDownManager countDown;

    [SerializeField] private float roundRestartDelay = 2f;

    [SerializeField] private EndgameUi endgameUi;

    [SerializeField] private TextMeshProUGUI scorePlayer1;
    [SerializeField] private TextMeshProUGUI scorePlayer2;

    [SerializeField] private SmashMinigame _minigameSmashUi;
    [SerializeField] private DontPressMinigame _minigameDontPressUi;

    [SerializeField] private IngameUi ingameUi;

    [SerializeField] private PlayerAvatar larren;
    [SerializeField] private PlayerAvatar tynha;

    [SerializeField] private AudioSource elevatorMusic;
    [SerializeField] private AudioSource hardcoreMusic;

    [SerializeField] private PlayableDirector rockVsScissorsTimeline;
    [SerializeField] private PlayableDirector paperVsRockTimeline;
    [SerializeField] private PlayableDirector scissorsVsPaperTimeline;

    private void Start()
    {
        rockVsScissorsTimeline.stopped += OnCustsceneEnd;
        paperVsRockTimeline.stopped += OnCustsceneEnd;
        scissorsVsPaperTimeline.stopped += OnCustsceneEnd;

        countDown.OnTimesUp += EndTurn;
        _player1 = FindObjectsOfType<PlayerController>().First(x => x.playerId == 1);
        _player2 = FindObjectsOfType<PlayerController>().First(x => x.playerId == 2);

        _player1.SetGameMode(PlayerController.GameMode.Preparation);
        _player2.SetGameMode(PlayerController.GameMode.Preparation);

        _player1.avatar = larren;
        _player2.avatar = tynha;

        _player1.onPrepared += OnPlayerPrepared;
        _player2.onPrepared += OnPlayerPrepared;
    }

    private void OnPlayerPrepared(PlayerController obj)
    {
        if (_player1.IsPrepared && _player2.IsPrepared)
        {
            elevatorMusic.Play();
            ingameUi.StartGame(BeginRound);
        }
    }

    private void OnDestroy()
    {
        _player1.onJoined -= OnPlayerPrepared;
        _player2.onJoined -= OnPlayerPrepared;
    }

    private void EndTurn()
    {
        Move move1 = _player1.GetMove();
        Move move2 = _player2.GetMove();

        _player1.EndTurn();
        _player2.EndTurn();

        Debug.Log("Player 1 plays " + move1 + " | Player 2 plays " + move2);

        if (move1 == move2)
        {
            Debug.Log("Draw");
        }
        else if (move1 == Move.Paper && move2 == Move.Rock ||
                 move1 == Move.Rock && move2 == Move.Scissors ||
                 move1 == Move.Scissors && move2 == Move.Paper)
        {
            ++_player1.score;
            rockVsScissorsTimeline.transform.localScale = new Vector3(-1f, 1f, 1f);
            paperVsRockTimeline.transform.localScale = new Vector3(-1f, 1f, 1f);
            scissorsVsPaperTimeline.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            ++_player2.score;
            rockVsScissorsTimeline.transform.localScale = Vector3.one;
            paperVsRockTimeline.transform.localScale = Vector3.one;
            scissorsVsPaperTimeline.transform.localScale = Vector3.one;
        }

        UpdateScore();

        if (Mathf.Abs(_player1.score - _player2.score) >= 2)
        {
            elevatorMusic.Stop();
            hardcoreMusic.Play();
            int nextGame = new System.Random().Next(0, 2);
            switch (nextGame)
            {
                case 0:
                    StartMinigameSmash();
                    break;
                case 1:
                    StartMinigameDontPress();
                    break;
            }

//            StartMinigameSmash();
//            EndGame();
            return;
        }

        _player1.SetGameMode(PlayerController.GameMode.Cutscene);
        _player2.SetGameMode(PlayerController.GameMode.Cutscene);
        if (move1 == Move.Rock && move2 == Move.Scissors ||
            move2 == Move.Rock && move1 == Move.Scissors)
        {
            rockVsScissorsTimeline.Play();
        }
        else if (move1 == Move.Paper && move2 == Move.Rock ||
                 move2 == Move.Paper && move1 == Move.Rock)
        {
            paperVsRockTimeline.Play();
        }
        else if (move1 == Move.Scissors && move2 == Move.Paper ||
                 move2 == Move.Scissors && move1 == Move.Paper)
        {
            scissorsVsPaperTimeline.Play();
        }
        else
        {
            StartCoroutine(StartNewRound());
        }
    }

    private void OnCustsceneEnd(PlayableDirector obj)
    {
        StartCoroutine(StartNewRound());
    }

    private void UpdateScore()
    {
        scorePlayer1.text = _player1.score.ToString();
        scorePlayer2.text = _player2.score.ToString();
    }

    private IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(roundRestartDelay);
        BeginRound();
    }

    private void BeginRound()
    {
        countDown.Restart();
        _player1.BeginTurn();
        _player2.BeginTurn();
    }

    private void StartMinigameSmash()
    {
        _player1.SetGameMode(PlayerController.GameMode.SmashMinigame);
        _player2.SetGameMode(PlayerController.GameMode.SmashMinigame);
        _minigameSmashUi.StartMinigame();
    }

    private void StartMinigameDontPress()
    {
        _player1.SetGameMode(PlayerController.GameMode.DontPressMinigame);
        _player2.SetGameMode(PlayerController.GameMode.DontPressMinigame);
        _minigameDontPressUi.StartMinigame();
    }

    public void OnMinigameEnd(bool player1Won)
    {
        hardcoreMusic.Stop();
        elevatorMusic.Play();
        if (player1Won && _player1.score >= _player2.score + 2 ||
            !player1Won && _player2.score >= _player1.score + 2)
        {
            EndGame();
        }
        else
        {
            if (_player1.score < _player2.score) ++_player1.score;
            else if (_player2.score < _player1.score) ++_player2.score;
            UpdateScore();
            StartCoroutine(StartNewRound());
        }
    }

    private void EndGame()
    {
        if (_player1.score > _player2.score)
        {
            WinnerStatic.WinnerText = "Player 1";
        }
        else
        {
            WinnerStatic.WinnerText = "Player 2";
        }

        SceneManager.LoadScene("EndGame");
    }
}