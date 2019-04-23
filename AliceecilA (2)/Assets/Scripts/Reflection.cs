using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    private SpriteRenderer elica;
    public Dialogue dia;
    private float alphaColor;

    // Start is called before the first frame update
    void Start()
    {
        elica = this.GetComponent<SpriteRenderer>();
        alphaColor = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            elica.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            elica.enabled = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        /*if (dia.index >= dia.words.Length - 1)
        {
            // every x seconds make the reflection fade????
            alphaColor -= 0.001f;

            elica.color = new Color(1f, 1f, 1f, alphaColor);
        }*/
    }
}
