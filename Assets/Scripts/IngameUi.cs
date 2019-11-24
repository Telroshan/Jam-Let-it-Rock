using System;
using System.Collections;
using UnityEngine;

public class IngameUi : MonoBehaviour
{
    [SerializeField] private Animator playerOneInputs;
    [SerializeField] private Animator playerTwoInputs;
    [SerializeField] private Animator preparationOverlay;
    [SerializeField] private CountDownManager countDownManager;

    private static readonly int Game = Animator.StringToHash("StartGame");

    public void StartGame(Action endAnimationCallback)
    {
        StartCoroutine(StartGameCoroutine(endAnimationCallback));
    }

    private IEnumerator StartGameCoroutine(Action endAnimationCallback)
    {
        playerOneInputs.SetTrigger(Game);
        playerTwoInputs.SetTrigger(Game);
        preparationOverlay.SetTrigger(Game);
        yield return new WaitForSeconds(1.5f);
        countDownManager.gameObject.SetActive(true);
        endAnimationCallback?.Invoke();
    }
}