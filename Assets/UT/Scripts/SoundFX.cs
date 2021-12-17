using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public static SoundFX Instance;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] audioClip;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
    
    public void PlaySound(int index) {
        audioSource.clip = audioClip[index];
        audioSource.Play();
    }

    public void PlayVoice(int index,AudioSource _audio) {
        _audio.clip = audioClip[index];
        _audio.Play();
    }

    public void StopVoice(int index,AudioSource _audio) {
        _audio.clip = audioClip[index];
        _audio.Stop();
    }


}
