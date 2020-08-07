using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingManager : Singleton<EndingManager>
{
    [Header("References")]
    [SerializeField] private EndingSoundEffects endingSoundEffects = default;
    [SerializeField] private TextMeshProUGUI line1 = default;
    [SerializeField] private TextMeshProUGUI line2 = default;
    [SerializeField] private TextMeshProUGUI line3 = default;
    [SerializeField] private TextMeshProUGUI line4 = default;
    [SerializeField] private TextMeshProUGUI finalLine = default;

    [Header("Attributes")]
    [SerializeField] private float textSpeed = 0.06f;
    [SerializeField] private float pauseTimeBetweenLines = 2f;

    [Header("Read-Only")]
    [SerializeField] private TextMeshProUGUI currentLineToUpdate;
    [TextArea(1, 5)]
    [SerializeField] private string textToDisplay;
    [TextArea(1, 5)]
    [SerializeField] private string currentTextDisplayed;
    [TextArea(1, 5)]
    [SerializeField] private string firstLineFirstPart;
    [TextArea(1, 5)]
    [SerializeField] private string secondLineFirstPart;

    private EndingOptionManager endingOptionManager;

    private WaitForSeconds textWaitTime;
    private WaitForSeconds lineWaitTime;

    // This whole sequence is hard-coded, please forgive me for I have sinned. I'm sowwy ;^;

    private void Awake() {
        endingOptionManager = EndingOptionManager.Instance;

        textWaitTime = new WaitForSeconds(textSpeed);
        lineWaitTime = new WaitForSeconds(pauseTimeBetweenLines);
    }

    private void Start() {
        line1.gameObject.SetActive(false);
        line2.gameObject.SetActive(false);
        line3.gameObject.SetActive(false);
        line4.gameObject.SetActive(false);
        finalLine.gameObject.SetActive(false);

        SoundManager.Instance.PlayMenuMusic();

        EndingEffectManager.Instance.BlackenOut(0.5f);
        StartCoroutine(HandleLine1());
    }

    public void HandleLine(int questionIndex, string buttonAnswer) {
        switch(questionIndex) {
            case 1:
                StartCoroutine(HandleLine2Question1(buttonAnswer));
                break;
            case 2:
                StartCoroutine(HandleLine2Question2(buttonAnswer));
                break;
            case 3:
                StartCoroutine(HandleLine3Question1(buttonAnswer));
                break;
            case 4:
                StartCoroutine(HandleLine3Question2(buttonAnswer));
                break;
        }
    }

    private IEnumerator HandleLine1() {
        yield return new WaitForSeconds(0.5f);

        line1.gameObject.SetActive(true);

        currentLineToUpdate = line1;
        textToDisplay = "I am Paul. I used to be a great Crystal Air pilot with over 11,500 flying hours.";

        for(int characterIndex = 0; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        // SoundEffect to signal new line
        endingSoundEffects.PlayNewLineSound();

        yield return lineWaitTime;
        StartCoroutine(HandleLine2());
    }

    private IEnumerator HandleLine2() {
        line2.gameObject.SetActive(true);

        currentLineToUpdate = line2;
        textToDisplay = "Until one day, many years ago, I was involved in a plane crash. I still don't remember much, but I know the type of plane I was flying was a...";

        for(int characterIndex = 0; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        endingOptionManager.ShowOption(1);
    }

    private IEnumerator HandleLine2Question1(string buttonAnswer) {
        string previousText = "Until one day, many years ago, I was involved in a plane crash. I still don't remember much, but I know the type of plane I was flying was a ";
        string nextText = " with the flight number";

        firstLineFirstPart = previousText + buttonAnswer + nextText;

        textToDisplay = firstLineFirstPart + "...";

        for(int characterIndex = previousText.Length; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        endingOptionManager.ShowOption(2);
    }

    private IEnumerator HandleLine2Question2(string buttonAnswer) {
        string previousText = firstLineFirstPart;
        string nextText = ".";

        textToDisplay = previousText + " " + buttonAnswer + nextText;

        for(int characterIndex = previousText.Length; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        // SoundEffect to signal new line
        endingSoundEffects.PlayNewLineSound();

        yield return lineWaitTime;
        StartCoroutine(HandleLine3());
    }

    private IEnumerator HandleLine3() {
        line3.gameObject.SetActive(true);

        currentLineToUpdate = line3;
        textToDisplay = "I still don't know exactly why the plane crashed but I know that it crashed into...";

        for(int characterIndex = 0; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        endingOptionManager.ShowOption(3);
    }

    private IEnumerator HandleLine3Question1(string buttonAnswer) {
        string previousText = "I still don't know exactly why the plane crashed but I know that it crashed into ";
        string nextText = " and";

        secondLineFirstPart = previousText + buttonAnswer + nextText;

        textToDisplay = secondLineFirstPart + "...";

        for(int characterIndex = previousText.Length; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        endingOptionManager.ShowOption(4);
    }

    private IEnumerator HandleLine3Question2(string buttonAnswer) {
        string previousText = secondLineFirstPart;
        string nextText = ".";

        textToDisplay = previousText + " " + buttonAnswer + nextText;

        for(int characterIndex = previousText.Length; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        // SoundEffect to signal new line
        endingSoundEffects.PlayNewLineSound();

        yield return lineWaitTime;
        StartCoroutine(HandleLine4());
    }

    private IEnumerator HandleLine4() {
        line4.gameObject.SetActive(true);

        currentLineToUpdate = line4;
        textToDisplay = "I am thankful to still be alive today.";

        for(int characterIndex = 0; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        // SoundEffect to signal new line
        endingSoundEffects.PlayNewLineSound();

        yield return lineWaitTime;
        StartCoroutine(HandleLine5());
    }

    private IEnumerator HandleLine5() {
        finalLine.gameObject.SetActive(true);

        currentLineToUpdate = finalLine;
        textToDisplay = "And that... is probably the reason why I retired.";

        for(int characterIndex = 0; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return textWaitTime;
        }

        // SoundEffect to signal new line
        endingSoundEffects.PlayNewLineSound();
    }

    private void UpdateLine() {
        endingSoundEffects.PlayRandomTypeSound();

        currentLineToUpdate.text = currentTextDisplayed;
    }
}
