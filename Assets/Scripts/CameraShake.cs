using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public float duration = 1f;
    public float magnitude = 600f;
    public CountDownManager countDownManager;
    
    
    private bool _currentlyShaking = false;
    
    public void Shake()
    {
        if (_currentlyShaking) return;
        _currentlyShaking = true;
        StartCoroutine(ShakeCamera(duration, magnitude));
    }

    public void Start()
    {
        countDownManager.OnTimesUp += Shake;
    }

    private IEnumerator ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalPos = transform.position;
        
        float elapsed = 0f;

        while (elapsed < duration)
        {

            float x = Random.Range(-1f, 1f) * magnitude * 0.1f;
            float y = Random.Range(-1f, 1f) * magnitude * 0.1f;
            
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            
            yield return null;
        }

        _currentlyShaking = false;
        transform.localPosition = new Vector3(0,0,0);
    }
}
