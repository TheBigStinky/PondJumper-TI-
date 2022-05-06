
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{

    public static bool paused = false;
    GameObject PauseCanvas1;
    GameObject AudioManager;
    GameObject AimCanvas;
    GameObject PauseBlock;
    FirstPersonControls action;

    private void Awake()
    {
        PauseCanvas1 = GameObject.Find("PauseMenu");
        AimCanvas = GameObject.Find("CrossHairBase");
        AudioManager = GameObject.Find("AudioManager 1");
        PauseBlock = GameObject.Find("PauseBlock");
        action = new FirstPersonControls();
    }


    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public void Start()
    {
        PauseCanvas1.SetActive(false);
        PauseBlock.SetActive(false);

        Resume();
        action.Player.Paused.performed += _ => DeterminePause();
    }

    private void DeterminePause()
    {
        if (paused)
        {
            Resume();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        //AudioManager.SetActive(false);
        paused = true;
        AimCanvas.SetActive(false);
        PauseCanvas1.SetActive(true);
        PauseBlock.SetActive(true);
        Cursor.lockState = CursorLockMode.None; 
        
    }



    public void Resume()
    {

        Time.timeScale = 1;
        AudioListener.pause = false;
        AudioManager.SetActive(true);
        paused = false;
        PauseCanvas1.SetActive(false);
        AimCanvas.SetActive(true);
        PauseBlock.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

}

//EDITEDITEDIT


