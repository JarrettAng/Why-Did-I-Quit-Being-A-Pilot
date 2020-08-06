using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject mainPanel = default;
    [SerializeField] private GameObject settingsPanel = default;
    [SerializeField] private GameObject creditsPanel = default;

    public void ShowMainPanel() {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowSettingsPanel() {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ShowCreditsPanel() {
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
}
