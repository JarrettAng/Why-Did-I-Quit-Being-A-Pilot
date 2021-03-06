﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Settings : MonoBehaviour
{
    public class UnityFloatEvent : UnityEvent<float> { }
    public static UnityFloatEvent NewTextSpeedUpdate = new UnityFloatEvent(); 

    [Header("References")]
    [SerializeField] private Slider musicSlider = default;
    [SerializeField] private Slider sfxSlider = default;
    [SerializeField] private Slider textSpeedSlider = default;

    [Header("Read-Only")]
    [SerializeField] private SettingsData storedData;

    private SoundManager soundManager;

    private void Awake() {
        soundManager = SoundManager.Instance;

        storedData = SaveManager.LoadSettingsData();

        InitializeSavedSettings();

        void InitializeSavedSettings() {
            musicSlider.value = storedData.MusicVolume;
            sfxSlider.value = storedData.SFXVolume;
            textSpeedSlider.value = storedData.TextSpeed;
        }
    }

    public void UpdateMusicVolume(float sliderValue) {
        storedData.MusicVolume = sliderValue;

        soundManager.UpdateMusicVolume(sliderValue);
    }

    public void UpdateSFXVolume(float sliderValue) {
        storedData.SFXVolume = sliderValue;

        soundManager.UpdateSFXVolume(sliderValue);
    }

    public void UpdateTextSpeed(float sliderValue) {
        storedData.TextSpeed = sliderValue;
    }

    // Called when the player goes back to the main panel; Data is only saved upon exiting settings
    public void SaveSettings() {
        NewTextSpeedUpdate.Invoke(storedData.TextSpeed);

        SaveManager.SaveSettingsData(storedData);
    }
}
