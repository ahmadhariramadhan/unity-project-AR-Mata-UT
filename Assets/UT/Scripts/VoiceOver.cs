using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VoiceOver : MonoBehaviour
{
    public int voiceIndex;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private UnityEngine.UI.Image imageSound;
    [SerializeField]
    private Sprite[] spriteSound;
    private void Awake() {
        audioSource = this.gameObject.AddComponent<AudioSource>();
    }
    private void OnEnable() {
        
       PlayVoice();
    //    playTogle();
    }

    private void PlayVoice(){
        SoundFX.Instance.PlayVoice(voiceIndex,audioSource);
    }

    public void PlayStopVoice(bool _play){
        if (_play)
        {
            audioSource.enabled=false;
            imageSound.sprite = spriteSound[1];
        }else{
            audioSource.enabled=true;
           imageSound.sprite = spriteSound[0]; 
        }
        
    }

    // public void playTogle(){
    //     togleButton.onValueChanged.AddListener(delegate{PlayStopVoice(togleButton);});
    // }
}
