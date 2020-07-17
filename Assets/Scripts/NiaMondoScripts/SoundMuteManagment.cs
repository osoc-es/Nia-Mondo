using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMuteManagment : MonoBehaviour
{
    private static SoundMuteManagment _instance;

    public static SoundMuteManagment Instance { get { return _instance; } }

    private List<float> volumes = new List<float>();

    private List<AudioSource> audioSources;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            audioSources=new List<AudioSource>();
        }
    }



    private void Start(){
         FindObjectsOfType(typeof(AudioSource));
          foreach(AudioSource s in FindObjectsOfType(typeof(AudioSource))){
                audioSources.Add(s);
                volumes.Add(s.volume);
          }

    }

    public void MuteAllSound(){
        foreach(AudioSource s in audioSources){
            if(s!=null)
            s.volume = 0f;

        }
    }
    public void UnMuteAllSounds(){
        foreach(AudioSource s in audioSources){
            if(s!=null){
                int index = audioSources.FindIndex(a => a.Equals(s));
                s.volume = volumes[index];
            }
            
        }
    }


}
