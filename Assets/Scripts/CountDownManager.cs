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
    
    private float _remainningTime;
    private bool _countdownInProgress = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCountDown();
    }

    public void StartCountDown()
    {
        TextMeshProUgui.text = StartTimeBase.ToString("0.00");
        _remainningTime = StartTimeBase;
        _countdownInProgress = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_countdownInProgress)
        {
            _remainningTime -= Time.deltaTime;
            if (_remainningTime <= 0)
            {
                _remainningTime = 0;
                _countdownInProgress = false;
                OnTimesUp?.Invoke();
            }
            LoadingBar.fillAmount = Mathf.Clamp01(_remainningTime / StartTimeBase);
            
            TextMeshProUgui.text = _remainningTime.ToString("0.00");
        }
       

    }
}
