using UnityEngine.Audio;
using System;
using UnityEngine.UI;
using UnityEngine;


//do not change. you do not have to set up anything in the inspector anymore. 
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
   

    void Awake()
    {
        //Debug.Log(SliderScript.mainVolume + "this is the main volume, but from the audio manager");

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.volume = SliderScript.mainVolume;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }

       
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();


    }

    public void VolumeChange()
    {
        //for (int i = 0; i < sounds.Length; i++)
       // {
         //   sounds[i].volume = SliderScript.mainVolume;
            

      //  }

        foreach (Sound s in sounds)
        {
            s.source.volume = SliderScript.mainVolume;
            s.volume = SliderScript.mainVolume;


        }
        //Debug.Log("this is running?" + sounds[0].volume);


    }

    public Sound Playing(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return null;
        }
        return s;


    }

}