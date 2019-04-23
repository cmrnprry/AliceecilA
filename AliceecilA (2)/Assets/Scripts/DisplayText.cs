using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI display;

    //dialogue
    public string[] words;

    //what char of dialogue we're on
    public int index;

    //how long before each letter of dialgue is shows
    public float waitSpeed;

    //continue button
    public GameObject proceed;

    public bool show = false;

    // Start is called before the first frame update
    void Start()
    {
        //stops the player from moving
        GameObject.Find("Player").GetComponent<Movement>().enabled = false;

        //Disables the continue Button
        proceed.SetActive(false);

        //clears intial text
        display.text = "";

        //does the thing in IEnumerator Type()
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Continue"))
        {
            Display();
        }

        if (show)
        {
            //if all the text is displayed, show the continue button
            if (display.text == words[index])
            {
                proceed.SetActive(true);
                //Debug.Log("button should be on");

                if (Input.GetButtonDown("Continue"))
                {
                    //Debug.Log("Play next dialogue");
                    Next();
                }
            }
        }
    }

    IEnumerator Type()
    {
        //Debug.Log("Say the words");
        foreach (char character in words[index].ToCharArray())
        {
            display.text += character;
            yield return new WaitForSeconds(waitSpeed);
        }
    }

    //proceeds the next line of dialogue
    public void Next()
    {
        //sets the continue button to be false
        proceed.SetActive(false);

        //clears text and goes to next line of dialogue
        if (index < words.Length - 1)
        {
            index++;
            display.text = "";
            StartCoroutine(Type());
        }

        //if there is no more dialogue to be shown
        else
        {
            //clears text
            display.text = "";

            //returns the players movement
            GameObject.Find("Player").GetComponent<Movement>().enabled = true;
            show = false;

        }
    }

    public void Display()
    {
        StartCoroutine(Type());
        show = true;

    }
}

