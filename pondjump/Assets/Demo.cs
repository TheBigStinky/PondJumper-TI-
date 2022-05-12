using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Demo : MonoBehaviour
{
    public GameObject[] quits;
    GameObject DemoPanel;
    Image DemoFrog;
    public bool demoMode;
    float resetHold;
    FirstPersonControls firstPersonControls;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonControls = new FirstPersonControls();
        firstPersonControls.Player.Enable();

        resetHold = 0;


        if (this.tag == "Player")
        {
            DemoFrog = GameObject.Find("froggy").GetComponent<Image>();
            DemoPanel = GameObject.Find("DemoPanel");
        }
            

        if (demoMode)
        {
            for (int i = 0; i < quits.Length; i++)
            {
                quits[i].SetActive(false);
            }

            if (this.tag == "Player")
            {
                DemoPanel.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if (this.tag == "Player")
        {
            DemoFrog.fillAmount = resetHold;
        }

        if(firstPersonControls.Player.DemoReset.ReadValue<float>() > .5)
        {
            if (resetHold < 1)
            {
                resetHold += 0.01f;
            }
            else if (resetHold >= 1)
            {
                Time.timeScale = 1;
                AudioListener.pause = false;
                SceneManager.LoadScene(0);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if(resetHold > 0)
        {
            resetHold -= 0.005f;
        }
        
    }
}
