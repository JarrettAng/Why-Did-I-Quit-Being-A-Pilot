using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [Header("Attributes")]
    [SerializeField] private int beepFrequency = 3;

    [Header("Read-Only")]
    [SerializeField] private float textSpeed = 0.025f;
    [SerializeField] private int charactersPassed = 0;

    private SoundManager soundManager;

    private void Awake() {
        soundManager = SoundManager.Instance;
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
}
