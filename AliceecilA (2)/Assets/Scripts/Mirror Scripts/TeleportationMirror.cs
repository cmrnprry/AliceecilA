using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationMirror : MonoBehaviour
{
    public GameObject partner;
    private GameObject player;

    public bool canTeleport = true;
    public bool teleportPosition;

    private float delay = 0.5f;
    private float delayCounter;
    private bool isDelay;

    private BoxCollider2D bc;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        delayCounter = delay;
        isDelay = false;

        bc = partner.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Teleport");
            teleportPosition = true;
            isDelay = true;

            bc.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("teleport = false");
            teleportPosition = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (canTeleport && teleportPosition)
        {
            Debug.Log("Teleport = true");
            canTeleport = false;
            teleportPosition = false;
            player.transform.position = partner.transform.position;
        }

        if (isDelay)
        {
            delayCounter -= Time.deltaTime;
            canTeleport = false;
        }

        if (delayCounter <= 0)
        {
            delayCounter = delay;
            isDelay = false;
            canTeleport = true;
            bc.enabled = true;
        }
    }
}
