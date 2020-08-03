using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class DialogueDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI nameText = default;
    [SerializeField] private TextMeshProUGUI contentText = default;

    private SceneManager sceneManager;
    private RectTransform rectTransform;

    private void Awake() {
        sceneManager = SceneManager.Instance;
        rectTransform = GetComponent<RectTransform>();
    }

    public void DisplayContentText(string text) {
        contentText.text = text;
    }

    [YarnCommand("DisplayName")]
    public void DisplayName(string characterName) {
        string nameToDisplay;
        
        switch(characterName) {
            case "Grandfather":
                nameToDisplay = "You";
                break;
            case "Daughter":
                nameToDisplay = "Amanda, your daughter";
                break;
            case "Son":
                nameToDisplay = "Ryan, your son";
                break;
            case "Grandson":
                nameToDisplay = "Oscar, your grandson";
                break;
            case "None":
                nameToDisplay = null;
                break;
            default:
                nameToDisplay = characterName;
                break;
        }

        DisplayNameText(nameToDisplay);

        rectTransform.anchoredPosition = sceneManager.GetDialoguePositionFor(characterName);
    }

    private void DisplayNameText(string name) {
        if(name == null) {
            if(nameText.gameObject.activeSelf == true) nameText.gameObject.SetActive(false);
        } else {
            if(nameText.gameObject.activeSelf == false) nameText.gameObject.SetActive(true);
            nameText.text = name;
        }

    }
}
