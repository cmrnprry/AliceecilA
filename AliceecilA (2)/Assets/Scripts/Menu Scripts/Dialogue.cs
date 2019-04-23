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

    //Controlls the talking animation
    public GameObject Other;
    public GameObject Alice;

    private Animator OtherAnim;
    private Animator AliceAnim;

    //dialogue
    public string[] words;

    //what char of dialogue we're on
    public int index;

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

            OtherAnim.enabled = false;

            if (Other.tag == "Elica")
            {
                Other.SetActive(false);
            }

            //returns the players movement
            GameObject.Find("Player").GetComponent<Movement>().enabled = true;
            AliceAnim.SetBool("Talk", false);
            AliceAnim.SetBool("Idle", true);
        }
    }

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

        Debug.Log(Other.name);
        OtherAnim = Other.GetComponent<Animator>();
        Debug.Log(OtherAnim.gameObject.name);
        AliceAnim = Alice.GetComponent<Animator>();
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
            if (display.text.Substring(0, 1) == "A")
            {
                AliceBubble.SetActive(true);
                AliceAnim.SetBool("Talk", true);

                OtherAnim.enabled = false;
            }
            else
            {
                OtherBubble.SetActive(true);
                OtherAnim.enabled = true;

                AliceAnim.SetBool("Talk", false);
            }
        }
        else
        {
            AliceBubble.SetActive(false);
            OtherBubble.SetActive(false);

            AliceAnim.SetBool("Talk", false);
            OtherAnim.enabled = false;
        }
    }
}
