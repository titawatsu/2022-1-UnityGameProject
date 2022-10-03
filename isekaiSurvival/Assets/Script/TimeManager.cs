using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [Header("TextmeshProText")] 
    public TMP_Text timerText;

    private float initialTime;
    private float timer;

    public bool gameOver;
    private bool keeptimer = true;

    #region START_UPDATE
    private void Start() => GetStartTime();

    private void Update()
    {
        if (gameOver) Stoptimer();
        
        if (keeptimer) UpdateTimer();
    }
    #endregion

    #region CALCULATE_TIME
    private void GetStartTime()
    {
        initialTime = Time.time;
    }

    private void UpdateTimer()
    {
        
        timer = Time.time - initialTime;
        timerText.text = TimeToString(timer);
    }

    public float Stoptimer()
    {
        keeptimer = false;
        Debug.Log("Timer stopped at " + TimeToString(Stoptimer()));
        return timer; // return time
    }

    public string TimeToString(float t)
    {
        
        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("f2");
        string miliseconds = ((int)(t * 100f) % 100).ToString("D2");

        return minutes + ":" + seconds + ":" + miliseconds;
    }
    #endregion
}
