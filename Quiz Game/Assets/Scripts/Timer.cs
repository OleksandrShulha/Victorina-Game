using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerValue;


    [SerializeField] float timeToCompleteAnswer = 30f;
    [SerializeField] float timeToCorrecrAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQueastion = false;
    public float fillFraction;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;


        if (isAnsweringQueastion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteAnswer;
            }
            else
            {
                isAnsweringQueastion = false;
                timerValue = timeToCorrecrAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCorrecrAnswer;
            }
            else
            {
                isAnsweringQueastion = true;
                timerValue = timeToCompleteAnswer;
                loadNextQuestion = true;
            }
        }
    }
}
