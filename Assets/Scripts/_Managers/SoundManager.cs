using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Yarn.Unity;

public class SoundManager : Singleton<SoundManager>
{
    [Header("References")]
    [SerializeField] private AudioMixerGroup musicMixer = default;
    [SerializeField] private AudioMixerGroup sfxMixer = default;

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

    private void Start() {
        SettingsData savedData = SaveManager.LoadSettingsData();
        UpdateMusicVolume(savedData.MusicVolume);
        UpdateSFXVolume(savedData.SFXVolume);
    }

    #region Music
    [YarnCommand("PlayCalmMusic")]
    public void PlayCalmMusic() {
        PlaySound("CalmMusic");
        StopSound("ConcernMusic");
        StopSound("TenseMusic");
        StopSound("MenuMusic");
    }

    [YarnCommand("PlayConcernMusic")]
    public void PlayConcernMusic() {
        PlaySound("ConcernMusic");
        StopSound("CalmMusic");
        StopSound("TenseMusic");
        StopSound("MenuMusic");
    }

    [YarnCommand("PlayTenseMusic")]
    public void PlayTenseMusic() {
        PlaySound("TenseMusic");
        StopSound("CalmMusic");
        StopSound("ConcernMusic");
        StopSound("MenuMusic");
    }

    [YarnCommand("PlayMenuMusic")]
    public void PlayMenuMusic() {
        PlaySound("MenuMusic");
        StopSound("CalmMusic");
        StopSound("ConcernMusic");
        StopSound("TenseMusic");
    }
    #endregion

    [YarnCommand("PlaySound")]
    public void PlaySound(string name) {
        if(soundDictionary.TryGetValue(name, out Sound requestedSound)) {
            if(!requestedSound.Source.isPlaying) requestedSound.Source.Play();
        } else {
            Debug.LogErrorFormat("SoundManager tried to play unknown sound ({0})", name);
        }
    }

    [YarnCommand("PlaySoundOneShot")]
    public void PlaySoundOneShot(string name) {
        if(soundDictionary.TryGetValue(name, out Sound requestedSound)) {
            requestedSound.Source.PlayOneShot(requestedSound.Clip);
        } else {
            Debug.LogErrorFormat("SoundManager tried to play unknown sound ({0})", name);
        }
    }

    [YarnCommand("StopSound")]
    public void StopSound(string name) {
        if(soundDictionary.TryGetValue(name, out Sound requestedSound)) {
            if(requestedSound.Source.isPlaying) requestedSound.Source.Stop();
        } else {
            Debug.LogErrorFormat("SoundManager tried to stop unknown sound ({0})", name);
        }
    }

    public void UpdateMusicVolume(float volume) {
        float actualVolumeLevel = Mathf.Log10(volume) * 20f;

        musicMixer.audioMixer.SetFloat("musicVol", actualVolumeLevel);
    }

    public void UpdateSFXVolume(float volume) {
        float actualVolumeLevel = Mathf.Log10(volume) * 20f;

        sfxMixer.audioMixer.SetFloat("sfxVol", actualVolumeLevel);
    }
}
