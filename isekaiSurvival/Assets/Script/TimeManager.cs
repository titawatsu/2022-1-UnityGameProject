using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [Header("TextmeshProText")]
    public TMP_Text timerText;

    public float timer;
    private float initialTime;

    #region START_UPDATE
    private void Start() => GetStartTime();

    private void Update()
    {
        UpdateTimer();
    }
    #endregion

    // functions to setup timer
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

    public string TimeToString(float t) // update timer's text in-game
    {

        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        string miliseconds = ((int)(t * 100f) % 100).ToString("00");

        return minutes + ":" + seconds + ":" + miliseconds;
    }
    #endregion
}