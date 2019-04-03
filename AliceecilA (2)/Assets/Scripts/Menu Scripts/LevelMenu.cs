using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        hidePaused();
    }

    //Restarts the level
    public void RestartLevel()
    {
        Debug.Log("restart");
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);

    }

    //Saves the level
    public void SavesLevel()
    {
        Debug.Log("save");

        //insert save data here

    }

    //Returns to Main Menu
    public void Menu()
    {
        Debug.Log("menu");
        SceneManager.LoadScene("Title");

    }

    //shows objects 
    public void showPaused()
    {
        Debug.Log("show");
        pauseMenu.SetActive(true);
    }

    //hides objects 
    public void hidePaused()
    {
        Debug.Log("hide");
        pauseMenu.SetActive(false);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

}
