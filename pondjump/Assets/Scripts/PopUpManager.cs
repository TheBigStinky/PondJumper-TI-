using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PopUpManager : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject pickupEffect;
    public GameObject PopUpTextCanvas;
    public GameObject PopUpImageCanvas;
    TextMeshProUGUI popUpText;
    TextMeshProUGUI popUpImageText;
    string _recievedText;
    Sprite _recievedImage;
    bool textOnly;
    PlayerInput playerInput;

    public int Collection;

    // Start is called before the first frame update
    void Start()
    {
        popUpText = GameObject.Find("RecievedText(T) (TMP)").GetComponent<TextMeshProUGUI>();
        popUpImageText = GameObject.Find("RecievedText(I) (TMP)").GetComponent<TextMeshProUGUI>();
        playerInput = GetComponent<PlayerInput>();

        PopUpTextCanvas.SetActive(false);
        PopUpImageCanvas.SetActive(false);
        audioManager = GameObject.Find("AudioManager 1").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PopUpText")
        {
            playerInput.enabled = false;
            textOnly = true;
            PopUpTextCanvas.SetActive(true);
            _recievedText = other.GetComponent<PopUp>().DeliveryText;

            popUpText.SetText(_recievedText);

            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            other.gameObject.SetActive(false);
        }
        else if (other.transform.tag == "PopUpImage")
        {
            playerInput.enabled = false;
            textOnly = false;
            PopUpImageCanvas.SetActive(true);
            _recievedText = other.GetComponent<PopUp>().DeliveryText;
            _recievedImage = other.GetComponent<PopUp>().DeliveryImage;

            popUpImageText.SetText(_recievedText);
            GameObject.Find("Image(I)").GetComponent<Image>().sprite = _recievedImage;


            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            other.gameObject.SetActive(false);
        }
        else if (other.transform.tag == "Collectable")
        {
            // Instantiate(pickupEffect, transform.position, transform.rotation);
            pickupEffect.GetComponent<ParticleSystem>().Play();
            audioManager.Play("CatchCast");
            Collection++;
            other.gameObject.SetActive(false);
            Debug.Log("Score: " + Collection);
        }
    }

    public void Continue()
    {
        if (textOnly)
        { PopUpTextCanvas.SetActive(false); }
        else { PopUpImageCanvas.SetActive(false); }
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        playerInput.enabled = true;
    }
}
