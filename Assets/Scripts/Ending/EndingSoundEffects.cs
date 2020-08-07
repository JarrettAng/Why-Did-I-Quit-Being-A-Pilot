using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSoundEffects : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private string typeEffect1 = "EndingPress1";
    [SerializeField] private string typeEffect2 = "EndingPress2";
    [SerializeField] private string typeEffect3 = "EndingPress3";
    [SerializeField] private string newLineEffect = "EndingNextLine";
    [SerializeField] private int beepFrequency = 2;

    [Header("Read-Only")]
    [SerializeField] private int charactersPassed = 0;

    private SoundManager soundManager;

    private void Awake() {
        soundManager = SoundManager.Instance;
    }

    public void PlayRandomTypeSound() {
        if(charactersPassed < beepFrequency) {
            charactersPassed++;
            return;
        }

        charactersPassed = 0;

        int randomIndex = Random.Range(1, 4);

        switch(randomIndex) {
            case 1:
                soundManager.PlaySoundOneShot(typeEffect1);
                break;
            case 2:
                soundManager.PlaySoundOneShot(typeEffect2);
                break;
            case 3:
                soundManager.PlaySoundOneShot(typeEffect3);
                break;
            default:
                Debug.LogErrorFormat("Tried to play unknown ending typing sound effect");
                break;
        }
    }

    public void PlayNewLineSound() {
        soundManager.PlaySound(newLineEffect);
    }
}
