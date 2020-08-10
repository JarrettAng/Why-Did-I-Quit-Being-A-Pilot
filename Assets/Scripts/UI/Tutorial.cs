using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button continueButton = default;

    private void Awake() {
        continueButton.onClick.AddListener(DisableSelf);
    }

    private void DisableSelf() {
        gameObject.SetActive(false);
    }
}
