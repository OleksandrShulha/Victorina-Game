using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    //поле для виведеня питання
    [SerializeField] TextMeshProUGUI questionText;
    //обєкт де ми берем питання
    [SerializeField] QustionSO qustionSO;

    //обєкти для виведення відповідей
    //[SerializeField] GameObject[] answerButtons;

    [SerializeField] GameObject[] answerButtons;

    void Start()
    {
        //виводим в поле питання з обєкту
        questionText.text = qustionSO.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = qustionSO.GetAnswer(i);
        }
    }

}
