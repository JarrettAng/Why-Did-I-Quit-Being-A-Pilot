using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDialBox : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EndingDialNumber thousands = default;
    [SerializeField] private EndingDialNumber hundreds = default;
    [SerializeField] private EndingDialNumber tens = default;
    [SerializeField] private EndingDialNumber ones = default;

    private void Start() {
        ToggleVisibility(false);
    }

    public void ToggleVisibility(bool state) {
        gameObject.SetActive(state);
    }

    // Used by the confirm button to submit the answer
    public void SubmitNumber() {
        string answer = thousands.CurrentNumber + hundreds.CurrentNumber + tens.CurrentNumber + ones.CurrentNumber;

        EndingOptionManager.Instance.OptionChosen(answer);
    }
}
