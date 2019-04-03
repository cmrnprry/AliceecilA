using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMirror : MonoBehaviour
{

    public float bounceHeight;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Bounce");
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * bounceHeight);
            //bounce is constant
        }
    }

}
