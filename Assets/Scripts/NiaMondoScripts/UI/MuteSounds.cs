using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MuteSounds : MonoBehaviour
{
    private bool isPlaying = true;

    public Sprite soundON;
    public Sprite soundOFF;

    private Image spriteRenderer;
    void Start(){
        spriteRenderer = GetComponent<Image>();
    }

    public void MutedPressed(){
        if(isPlaying)
        {
             SoundMuteManagment.Instance.MuteAllSound();
             isPlaying = false;
             spriteRenderer.sprite = soundOFF;
             
        }
        else {
             SoundMuteManagment.Instance.UnMuteAllSounds();
            isPlaying = true;
            spriteRenderer.sprite = soundON;

        }
    }

}
