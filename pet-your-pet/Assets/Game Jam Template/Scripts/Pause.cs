using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private ShowPanels showPanels;                      //Reference to the ShowPanels script used to hide and show UI panels
    private bool isPaused;                              //Boolean to check if the game is paused or not
    private StartOptions startScript;                   //Reference to the StartButton script

    void Awake()
    {
        showPanels = GetComponent<ShowPanels>();
        startScript = GetComponent<StartOptions>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused && !startScript.inMainMenu)
        {
            DoPause();
        }
        else if (Input.GetButtonDown("Cancel") && isPaused && !startScript.inMainMenu)
        {
            UnPause();
        }

    }

    public void DoPause()
    {
        //Set isPaused to true
        isPaused = true;
        //Set time.timescale to 0, this will cause animations and physics to stop updating
        Time.timeScale = 0;
        //call the ShowPausePanel function of the ShowPanels script
        showPanels.ShowPausePanel();
    }

    public void UnPause()
    {
        //Set isPaused to false
        isPaused = false;
        //Set time.timescale to 1, this will cause animations and physics to continue updating at regular speed
        Time.timeScale = 1;
        //call the HidePausePanel function of the ShowPanels script
        showPanels.HidePausePanel();
    }

    public void Restart()
    {
        UnPause();
        SceneManager.LoadScene(startScript.sceneToStart);
    }

    public void BackToMainMenu()
    {
        UnPause();
        SceneManager.LoadScene(0);
    }

}
