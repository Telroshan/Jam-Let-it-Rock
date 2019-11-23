using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDownManager : MonoBehaviour
{
    public float StartTimeBase = 5;
    public TextMeshProUGUI TextMeshProUgui;
    public Image LoadingBar;

    /// <summary>
    /// Called when time remaining == 0
    /// </summary>
    public Action OnTimesUp;

    private float _remainingTime;

    private bool _countdownInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCountDown();
    }

    public void StartCountDown()
    {
        TextMeshProUgui.text = StartTimeBase.ToString("0.00");
        _remainingTime = StartTimeBase;
        _countdownInProgress = true;
    }

    public void Restart()
    {
        _remainingTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_countdownInProgress)
        {
            _remainingTime -= Time.deltaTime;
            if (_remainingTime <= 0)
            {
                _remainingTime = 0;
                _countdownInProgress = false;
                OnTimesUp?.Invoke();
            }

            LoadingBar.fillAmount = Mathf.Clamp01(_remainingTime / StartTimeBase);

            TextMeshProUgui.text = _remainingTime.ToString("0.00");
        }
    }
}