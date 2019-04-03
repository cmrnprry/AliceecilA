using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //build indexes for the next level or the flipped level
    private int nextLevel;
    private int flipLevel;

    public void Start()
    {
        nextLevel = SceneManager.GetActiveScene().buildIndex + 2;
        flipLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //name of the scene
        var name = SceneManager.GetActiveScene().name;
        Debug.Log("name: " + name);

        //If the player reaches the Exit
        if (collision.transform.tag == "Transition")
        {
            //if the player reaches the Exit in the Flip Level
            if (name.Substring(name.Length - 4) == "Flip")
            {
                Debug.Log("Next Level Flipped: " + nextLevel);
                SceneManager.LoadScene(flipLevel);
            }
            else
            {
                Debug.Log("Next Level Normal: " + nextLevel);
                SceneManager.LoadScene(nextLevel);
            }
        }

        //If the Player falls out of the world
        if (collision.transform.tag == "Flip")
        {

            if (name.Substring(name.Length - 4) != "Flip")
            {
                Debug.Log("name: " + name.Substring(name.Length - 4));
                Debug.Log("Flipped Level: " + flipLevel);
                SceneManager.LoadScene(flipLevel);
            }
            else
            {
                Debug.Log("Restart");
                //resets the player to normal
                FindObjectOfType<Movement>().gameObject.SendMessage("ResetPlayer");
            }
        }
    }
}
