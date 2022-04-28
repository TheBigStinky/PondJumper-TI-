using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggers : MonoBehaviour
{
    public AudioSource playSounds;
    public bool isPlay;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playSounds.Play();


        }       
        
    }

    void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player") && isPlay == false)
        {
            playSounds.Stop();

        }
    }
}
