using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingDialNumber : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI number = default;

    [Header("Attributes")]
    [SerializeField] private int staringNumber = 0;

    [Header("Read-Only")]
    [SerializeField] private int currentNumber;

    private void Start() {
        SetNumber(staringNumber);
    }

    public string CurrentNumber {
        get { return currentNumber.ToString(); }
    }

    public void IncreaseNumber() {
        currentNumber++;
        SetNumber(currentNumber);
    }

    public void DecreaseNumber() {
        currentNumber--;
        SetNumber(currentNumber);
    }

    private void SetNumber(int newNumber) {
        if(currentNumber > 9) currentNumber = 0;
        if(currentNumber < 0) currentNumber = 9;

        number.text = currentNumber.ToString();
    }
}
