using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider volumeSlider;
   
    public static float mainVolume = 0.5f;
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

       // Debug.Log(mainVolume + "this is the main volume");
        volumeSlider.value = mainVolume;

       // mainVolume = curVolume;
    }

    // Update is called once per frame
    void Update()
    {
        volumeSlider.value = mainVolume;
        
    }

    public void changeVolume()
    {
        mainVolume = volumeSlider.value;
        //managerType.GetComponent<>
        audioManager.VolumeChange();
    }
}
