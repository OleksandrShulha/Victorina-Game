using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    //поле для виведеня питання
    [SerializeField] TextMeshProUGUI questionText;
    //обєкт де ми берем питання
    QustionSO qustionCurent;

    [SerializeField] List<QustionSO> qustion; 

    [Header("Answers")]
    //обєкти для виведення відповідей
    [SerializeField] GameObject[] answerButtons;
    //змінні для зберігання спрайтів по кілку
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correcAnswerSprite;
    bool hasAnswering;   //відповіли на питання чи ні

    [Header("Timer")]
    //для работы картинки таймера
    [SerializeField] Image timerImage;
    Timer timer;


    [Header("Score")]
    //поле для виведеня питання
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;


    void Start()
    {
        timer = FindAnyObjectByType<Timer>();
        scoreText.text = "Score: " + score;

        //виводим питання і відповіді
        GetNextQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnswering = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnswering && !timer.isAnsweringQueastion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void GetNextQuestion()
    {
        if(qustion.Count > 0)
        {
            SetButtonState(true);  //включаеем всі кнопки
            SetDefaultButtonSprite(); //на всі кнопкі вімашем спрайт по умолчанію
            GetRendomQuestion();
            DisplayQuestion(); //виводим питання
        }

    }

    void GetRendomQuestion()
    {
        int index = UnityEngine.Random.Range(0, qustion.Count);
        qustionCurent = qustion[index];

    }

    void DisplayAnswer(int index)
    {
        if (index == qustionCurent.GetCorrectIndexAnswer())
        {
            questionText.text = "Corecr!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            answerButtons[index].GetComponent<Image>().color = Color.green;
            buttonImage.sprite = correcAnswerSprite;
            score += 1;
            scoreText.text = "Score: " + score;


            //можна і так:
            // answerButtons[index].GetComponent<Image>().sprite = correcAnswerSprite;
        }
        else
        {


            if (index >=0)
            {
                questionText.text = "Dont Corecr!";
                answerButtons[index].GetComponent<Image>().color = Color.red;
                score -= 1;
                scoreText.text = "Score: " + score;

            }
            else
            {
                questionText.text = "Time is over";
                
            }
            answerButtons[qustionCurent.GetCorrectIndexAnswer()].GetComponent<Image>().sprite = correcAnswerSprite;
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnswering = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayQuestion()
    {
        //виводим в поле питання з обєкту
        questionText.text = qustionCurent.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = qustionCurent.GetAnswer(i);

            //можна щей так:
            //  answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = qustionSO.GetAnswer(i);
        }
    }

    void SetButtonState(bool stete)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Button>().interactable = stete;
        }
    }



    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
            answerButtons[i].GetComponent<Image>().color = Color.white;
        }
    }


}
