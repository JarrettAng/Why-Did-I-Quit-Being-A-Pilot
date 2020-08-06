using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("Attributes")]
    [SerializeField] private Sound[] sounds = default;

    private Dictionary<string, Sound> soundDictionary;

    private void Awake() {
        InitializeSounds();
        InitializeDictionaries();

        void InitializeSounds() {
            foreach(Sound sound in sounds) {
                sound.Source = gameObject.AddComponent<AudioSource>();
                sound.Source.clip = sound.Clip;

                sound.Source.outputAudioMixerGroup = sound.AudioMixerGroup;

                sound.Source.volume = sound.Volume;
                sound.Source.pitch = sound.Pitch;
                sound.Source.loop = sound.Loop;
            }
        }

        void InitializeDictionaries() {
            soundDictionary = new Dictionary<string, Sound>();

            foreach(Sound sound in sounds) {
                soundDictionary.Add(sound.Name, sound);
            }
        }
    }

    public void PlaySound(string name) {
        if(soundDictionary.TryGetValue(name, out Sound requestedSound)) {
            requestedSound.Source.Play();
        } else {
            Debug.LogErrorFormat("SoundManager tried to play unknown sound ({0})", name);
        }
    }

    public void StopSound(string name) {
        if(soundDictionary.TryGetValue(name, out Sound requestedSound)) {
            requestedSound.Source.Stop();
        } else {
            Debug.LogErrorFormat("SoundManager tried to stop unknown sound ({0})", name);
        }
    }
}
