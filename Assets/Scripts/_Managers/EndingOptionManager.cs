using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingOptionManager : Singleton<EndingOptionManager>
{
    [Header("References")]
    [SerializeField] private EndingOptionBox endingOptionBox = default;
    [SerializeField] private EndingDialBox endingDialBox = default;

    [Header("Read-Only")]
    [SerializeField] private List<string> answersGiven;
    [SerializeField] private int currentQuestionIndex;

    private EndingManager endingManager;

    public List<string> AnswersGiven {
        get { return answersGiven; }
    }

    private void Awake() {
        answersGiven = new List<string>();

        endingManager = EndingManager.Instance;
    }

    public void ShowOption(int questionIndex) {
        currentQuestionIndex = questionIndex;

        switch(questionIndex) {
            case 1:
                endingOptionBox.ToggleVisibility(true);
                endingOptionBox.ShowOption1();
                break;
            case 2:
                endingDialBox.ToggleVisibility(true);
                break;
            case 3:
                endingOptionBox.ToggleVisibility(true);
                endingOptionBox.ShowOption3();
                break;
            case 4:
                endingOptionBox.ToggleVisibility(true);
                endingOptionBox.ShowOption4();
                break;
            default:
                Debug.LogErrorFormat("Unknown option index ({0}) to display requested", questionIndex);
                break;
        }
    }

    public void OptionChosen(string buttonAnswer) {
        endingManager.HandleLine(currentQuestionIndex, buttonAnswer);

        answersGiven.Add(buttonAnswer);
    }
}
