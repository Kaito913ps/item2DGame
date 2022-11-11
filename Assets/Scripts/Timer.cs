using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshPro _timeText;

    [SerializeField]
    private float _totalTime;
    [SerializeField]
    private int _minutue;
    [SerializeField]
    private float _seconds;

    private float _oldSecounds;

    private void Start()
    {
        _totalTime = _minutue * 60 + _seconds;
        _oldSecounds = 0f;
    }

    void Update()
    {




        //var offset = TimeSpan.FromMinutes(_offset);

        //var time = TimeSpan.FromSeconds(Time.time);
        
        //var limit = offset - time;

        //m_TextMeshPro.text = $"{limit.Minutes:00}:{limit.Seconds:00}";

        //if(time < 0f)
        //{

        //}

        if(_totalTime <= 0f)
        {
            return;
        }

        _totalTime -= Time.deltaTime;

        _minutue = (int)_totalTime / 60;
        _seconds = _totalTime - _minutue / 60;

        if((int)_seconds != (int)_oldSecounds)
        {
            _timeText.text = $"{_minutue:00}:{_seconds:00}";
        }
        _oldSecounds = _seconds;

        if(_totalTime <= 0f)
        {
            //pause
        }
    }
}
