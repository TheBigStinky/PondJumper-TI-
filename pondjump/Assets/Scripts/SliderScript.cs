using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider volumeSlider;
   
    public static float mainVolume;
    public static bool gameRuns;
    public AudioManager audioManager;


    private void Awake()
    {
        volumeSlider = this.gameObject.GetComponent<Slider>();
        if (!gameRuns)
        {
            gameRuns = true;
            volumeSlider.value = 0.32f;


        }
    }
    void Start()
    {
       
       
        volumeSlider.value = mainVolume;

       // mainVolume = curVolume;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void changeVolume()
    {
        mainVolume = volumeSlider.value;
        //managerType.GetComponent<>
        //audioManager.VolumeChange();
    }
}
