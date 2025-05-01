using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {
    
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds, voiceSounds;
    public AudioSource musicSource, sfxSource, voiceSource;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name) {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null) {
            Debug.Log("Music Sound: " + name + " not found!");
        } else {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlayVoice(string name) {
        Sound s = Array.Find(voiceSounds, x => x.name == name);
        if (s == null) {
            Debug.Log("Voice Sound: " + name + " not found!");
        } else {
            voiceSource.clip = s.clip;
            voiceSource.Play();
        }
    }
    public void PlaySFX(string name) {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null) {
            Debug.Log("SFX Sound: " + name + " not found!");
        } else {
            sfxSource.PlayOneShot(s.clip);
            
        }
    }
}      


