using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    #region VariablesInInspector

    public Canvas MainMenuScreen;
    public Canvas CreditScreen;
    public Canvas OptionsScreen;
    private bool toggleFullScreen = true;

    #endregion


    #region ButtonsFunctions

    /// <summary>
    ///  for PLAY button
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    /// <summary>
    /// for QUIT button
    /// </summary>
    public void ExitApplication()
    {
        Application.Quit();
    }

    /// <summary>
    /// Credits screen handler
    /// </summary>
    public void ToggleCredits()
    {
        ToggleUIScreen(CreditScreen, MainMenuScreen);
    }

    /// <summary>
    /// Options screen handler
    /// </summary>
    public void ToggleOptions() 
    {
        ToggleUIScreen(OptionsScreen, MainMenuScreen);
    }

    /// <summary>
    /// Used to ative or disactive a screen
    /// </summary>
    /// <param name="selectedScreen">the screen you want to active or disactive</param>
    /// <param name="previousScreen">the previous screen</param>
    public void ToggleUIScreen(Canvas selectedScreen, Canvas previousScreen)
    {
        if (!selectedScreen.gameObject.activeInHierarchy)
        {
            selectedScreen.gameObject.SetActive(true);
            previousScreen.gameObject.SetActive(false);
            return;
        }
        else
        {
            previousScreen.gameObject.SetActive(true);
            selectedScreen.gameObject.SetActive(false);
            return;
        }
    }

    public void ToggleFullScreen()
    {
        if (toggleFullScreen)
        {
            Screen.fullScreen = true;
            toggleFullScreen = false;
            return;
        }
        else if (!toggleFullScreen)
        {
            Screen.fullScreen = false;
            toggleFullScreen = true;
            return;
        }
    }

    #endregion
}
