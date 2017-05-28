﻿using UnityEngine;

public class ShowPanels : MonoBehaviour
{
    public GameObject optionsPanel;                         //Store a reference to the Game Object OptionsPanel 
    public GameObject optionsTint;                          //Store a reference to the Game Object OptionsTint 
    public GameObject menuPanel;                            //Store a reference to the Game Object MenuPanel 
    public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 
    public GameObject aboutPanel;
    public GameObject scoresPanel;

    //Call this function to activate and display the Options panel during the main menu
    public void ShowOptionsPanel()
    {
        optionsPanel.SetActive(true);
        optionsTint.SetActive(true);
    }

    //Call this function to deactivate and hide the Options panel during the main menu
    public void HideOptionsPanel()
    {
        optionsPanel.SetActive(false);
        optionsTint.SetActive(false);
    }

    //Call this function to activate and display the main menu panel during the main menu
    public void ShowMenu()
    {
        menuPanel.SetActive(true);
    }

    //Call this function to deactivate and hide the main menu panel during the main menu
    public void HideMenu()
    {
        menuPanel.SetActive(false);
    }

    //Call this function to activate and display the Pause panel during game play
    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        optionsTint.SetActive(true);
    }

    //Call this function to deactivate and hide the Pause panel during game play
    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        optionsTint.SetActive(false);
    }

    public void ShowAboutPanel()
    {
        aboutPanel.SetActive(true);
    }

    public void HideAboutPanel()
    {
        aboutPanel.SetActive(false);
    }

    public void ShowScoresPanel()
    {
        scoresPanel.SetActive(true);
    }

    public void HideScoresPane()
    {
        scoresPanel.SetActive(false);
    }
}
