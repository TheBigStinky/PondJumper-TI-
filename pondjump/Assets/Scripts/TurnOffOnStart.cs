using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOnStart : MonoBehaviour
{
    public GameObject[] itemToTurnOff;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject thing in itemToTurnOff)
        {
            thing.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
