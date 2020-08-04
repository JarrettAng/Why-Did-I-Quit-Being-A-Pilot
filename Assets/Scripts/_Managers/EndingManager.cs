using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingManager : Singleton<EndingManager>
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI line1 = default;
    [SerializeField] private TextMeshProUGUI line2 = default;
    [SerializeField] private TextMeshProUGUI line3 = default;
    [SerializeField] private TextMeshProUGUI line4 = default;
    [SerializeField] private GameObject finalLine = default;

    [Header("Attributes")]
    [SerializeField] private float textSpeed = 0.06f;

    [Header("Read-Only")]
    [SerializeField] private TextMeshProUGUI currentLineToUpdate;
    [TextArea(1, 5)]
    [SerializeField] private string textToDisplay;
    [TextArea(1, 5)]
    [SerializeField] private string currentTextDisplayed;

    private WaitForSeconds waitTime;

    // This whole sequence is hard-coded, please forgive me for I have sinned. I'm sowwy ;^;

    private void Start() {
        waitTime = new WaitForSeconds(textSpeed);

        line1.gameObject.SetActive(false);
        line2.gameObject.SetActive(false);
        line3.gameObject.SetActive(false);
        line4.gameObject.SetActive(false);
        finalLine.SetActive(false);

        StartCoroutine(HandleLine1());
    }


    private IEnumerator HandleLine1() {
        line1.gameObject.SetActive(true);

        currentLineToUpdate = line1;
        textToDisplay = "I am Paul. I used to be a great Crystal Air pilot with over 11,500 flying hours.";

        for(int characterIndex = 0; characterIndex <= textToDisplay.Length; characterIndex++) {
            currentTextDisplayed = textToDisplay.Substring(0, characterIndex);
            UpdateLine();
            yield return waitTime;
        }
    }

    private void UpdateLine() {
        currentLineToUpdate.text = currentTextDisplayed;
    }
}
