using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingOptionBox : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI option1 = default;
    [SerializeField] private TextMeshProUGUI option2 = default;
    [SerializeField] private TextMeshProUGUI option3 = default;

    private void Start() {
        ToggleVisibility(false);
    }

    public void ToggleVisibility(bool state) {
        gameObject.SetActive(state);
    }

    public void ShowOption1() {
        UpdateOptionsText("private jet", "regional airliner", "wide-body airliner");
    }

    public void ShowOption3() {
        UpdateOptionsText("a mountain", "the woods", "the ocean");
    }

    public void ShowOption4() {
        UpdateOptionsText("I was the only survivor", "there were a few survivors", "nobody was hurt");
    }

    private void UpdateOptionsText(string option1Text, string option2Text, string option3Text) {
        option1.text = option1Text;
        option2.text = option2Text;
        option3.text = option3Text;
    }
}
