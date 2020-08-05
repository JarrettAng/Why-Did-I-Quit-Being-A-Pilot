using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingResult : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI resultText = default; 

    [Header("Attributes")]
    [SerializeField] private List<string> correctAnswers = default;
    [TextArea(1,5)]
    [SerializeField] private string allCorrectResult = "Congratulations! All of your answers are 100% correct!";
    [TextArea(1,5)]
    [SerializeField] private string wrongResult = "Unfortunately, not all your answers were correct.<br>Try getting Amanda to open up more for the right answers!<br>Or did you misremember what was said in the story?";

    [Header("Read-Only")]
    [SerializeField] private List<string> answersGiven;
    [SerializeField] private bool allAnswersCorrect;
    
    private void Start() {
        answersGiven = EndingOptionManager.Instance.AnswersGiven;
        CompareAnswers();
    }

    private void CompareAnswers() {
        allAnswersCorrect = true;

        for(int index = 0; index < answersGiven.Count; index++) {
            if(answersGiven[index] != correctAnswers[index]) {
                allAnswersCorrect = false;
                break;
            }
        }

        if(allAnswersCorrect) {
            resultText.text = allCorrectResult;
        } else {
            resultText.text = wrongResult;
        }
    }

    public void ReturnToMenu() {
        GameSceneManager.Instance.LoadMenuScene();
    }
}
