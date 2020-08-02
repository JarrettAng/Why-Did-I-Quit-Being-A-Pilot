using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button continueButton = default;

    [Header("Attributes")]
    [SerializeField] private float cooldown = 0.1f;

    // Used to prevent accidental tapping and skipping of dialogue
    public void DisableButton() {
        continueButton.enabled = false;
        Invoke("EnableButton", cooldown);
    }

    private void EnableButton() {
        continueButton.enabled = true;
    }
}
