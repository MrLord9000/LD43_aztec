using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame ()
    {
        SceneManager.LoadScene("Level_01_main");
    }

    public void HiddenCredits()
    {
        SceneManager.LoadScene("CreditsSecret");
    }
    public void Exit()
    {
        Application.Quit();
    }
}