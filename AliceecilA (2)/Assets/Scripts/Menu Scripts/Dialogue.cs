using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //displays the text
    public TextMeshProUGUI display;
    public GameObject AliceBubble;
    public GameObject OtherBubble;
    //dialogue
    public string[] words;

    //what char of dialogue we're on
    private int index;

    //how long before each letter of dialgue is shows
    public float waitSpeed;

    //continue button
    public GameObject proceed;

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

            AliceBubble.SetActive(false);
            OtherBubble.SetActive(false);

            //returns the players movement
            FindObjectOfType<Movement>().jumpForce = 275f;
            FindObjectOfType<Movement>().maxSpeed = 5f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //stops the player from moving
        FindObjectOfType<Movement>().jumpForce = 0;
        FindObjectOfType<Movement>().maxSpeed = 0;

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

        if (display.text.Length > 4)
        {
            if (display.text.Substring(0, 5) == "Alice")
            {
                AliceBubble.SetActive(true);
            }
            else
            {
                OtherBubble.SetActive(true);
            }
        }
        else
        {
            AliceBubble.SetActive(false);
            OtherBubble.SetActive(false);
        }
    }
}
