using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndingOptionAnswer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI textComponent = default;

    public void SubmitAnswer() {
        EndingOptionManager.Instance.OptionChosen(textComponent.text);
    }
}
