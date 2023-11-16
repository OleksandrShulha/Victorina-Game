using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    //поле для виведеня питання
    [SerializeField] TextMeshProUGUI questionText;
    //обєкт де ми берем питання
    [SerializeField] QustionSO qustionSO;

    //обєкти для виведення відповідей
    [SerializeField] GameObject[] answerButtons;

    //змінні для зберігання спрайтів по кілку
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correcAnswerSprite;


    void Start()
    {
        GetNextQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        if(index == qustionSO.GetCorrectIndexAnswer())
        {
            questionText.text = "Corecr!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            answerButtons[index].GetComponent<Image>().color = Color.green;
            buttonImage.sprite = correcAnswerSprite;

            //можна і так:
            // answerButtons[index].GetComponent<Image>().sprite = correcAnswerSprite;
        }
        else
        {
            questionText.text = "Dont Corecr!";
            answerButtons[index].GetComponent<Image>().color = Color.red;
            answerButtons[qustionSO.GetCorrectIndexAnswer()].GetComponent<Image>().sprite = correcAnswerSprite;
        }

        SetButtonState(false);
    }

    void DisplayQuestion()
    {
        //виводим в поле питання з обєкту
        questionText.text = qustionSO.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = qustionSO.GetAnswer(i);

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

    void GetNextQuestion()
    {
        
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
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
