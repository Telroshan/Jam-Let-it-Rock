using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    public float StartTime = 5;

    public TextMeshProUGUI TextMeshProUgui;
    
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUgui.text = StartTime.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        StartTime -= Time.deltaTime;
        if (StartTime <= 0)
        {
            StartTime = 0;
            //TODO: Call Next Round

        }
        TextMeshProUgui.text = StartTime.ToString("0.00");

    }
}
