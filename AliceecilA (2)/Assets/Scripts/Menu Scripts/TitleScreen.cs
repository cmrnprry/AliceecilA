using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Canvas popup;
    public bool isNewGame;


    private void Start()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (isNewGame)
        {
            //if not paused, stop time and show pause menu
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;

            }
            //if paused, start time and hide pause menu
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 0;
            }
        }
    }

    public void StartGame()
    {
        Debug.Log("start");
        isNewGame = true;
        popup.gameObject.SetActive(true);

    }

    public void NewGame(string buttonPressed)
    {
        if (buttonPressed == "yes")
        {
            Debug.Log("yes");
            SceneManager.LoadScene(1);
        }

        if (buttonPressed == "no")
        {
            Debug.Log("no");
            popup.gameObject.SetActive(false);
        }

        isNewGame = false;
    }


    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void LoadGame()
    {
        Debug.Log("load");
        //insert load game code
    }
}
