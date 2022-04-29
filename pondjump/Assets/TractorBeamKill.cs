using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamKill : MonoBehaviour
{
    Vector3 contactPoint;
    bool caught;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<Rigidbody>().isKinematic && other.tag == "Player")
        {
            caught = true;
        }
        else if(other.gameObject.GetComponent<CharacterController>().enabled && other.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().enabled = false;
            contactPoint = transform.position - other.transform.position;
            caught = true;
        }
    }

    private void FixedUpdate()
    {
        if(caught)
        {
            player.transform.position = transform.position + contactPoint;
            player.GetComponent<CheckpointDeathManager>().Damage += 0.1f;
        }

        if(player.GetComponent<CheckpointDeathManager>().Damage >= 1)
        {
            caught = false;
        }
    }
}
