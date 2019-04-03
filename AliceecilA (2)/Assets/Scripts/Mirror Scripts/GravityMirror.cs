using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMirror : MonoBehaviour
{
    private Movement script;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        script = player.GetComponent<Movement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Gravity Change");

            //Change gravity
            player.gameObject.GetComponent<Rigidbody2D>().gravityScale = player.gameObject.GetComponent<Rigidbody2D>().gravityScale * -1;

            //Flips player
            Vector3 rotate = player.transform.localEulerAngles;
            rotate.z += 180;
            player.transform.localEulerAngles = rotate;

            //fixes jump
            script.jumpForce = script.jumpForce * -1;
        }
    }
}
