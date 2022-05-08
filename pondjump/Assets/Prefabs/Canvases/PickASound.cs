using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickASound : MonoBehaviour
{
    [SerializeField] public string SoundClip;
    public AudioManager AudioManager;
    private AudioSource playSounds;

    public void Start()
    {
        playSounds = GetComponent<AudioSource>();

       // playSounds.clip = AudioManager.Playing(SoundClip).clip;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playSounds.Play();


        }

    }
}
