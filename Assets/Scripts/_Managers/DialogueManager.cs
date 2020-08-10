using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("References")]
    [SerializeField] private DialogueUI dialogueUI = default;

    [Header("Attributes")]
    [SerializeField] private int beepFrequency = 3;

    [Header("Read-Only")]
    [SerializeField] private float initialTextSpeed;
    [SerializeField] private float textSpeed = 0.025f;
    [SerializeField] private int charactersPassed = 0;

    private SoundManager soundManager;

    private void Awake() {
        Settings.NewTextSpeedUpdate.AddListener(UpdateTextSpeed);

        soundManager = SoundManager.Instance;

        initialTextSpeed = dialogueUI.textSpeed;

        float storedSpeedMultiplier = SaveManager.LoadSettingsData().TextSpeed;
        UpdateTextSpeed(storedSpeedMultiplier);
    }

    public float TextSpeed {
        get { return textSpeed; }
    }

    public void PlayDialogueSound(string text) {
        charactersPassed++;

        if(charactersPassed >= beepFrequency) {
            charactersPassed = 0;
            soundManager.PlaySoundOneShot("Dialogue");
        }
    }

    public void UpdateTextSpeed(float newSpeedMultiplier) {
        textSpeed = initialTextSpeed / newSpeedMultiplier;
        dialogueUI.textSpeed = textSpeed;
    }
}
