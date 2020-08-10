using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pausePanel = default;

    [Header("Read-Only")]
    [SerializeField] private bool isPaused;

    public void TogglePause(bool state) {
        isPaused = state;

        Time.timeScale = isPaused == true ? 0 : 1;

        pausePanel.SetActive(state);
    }
}
