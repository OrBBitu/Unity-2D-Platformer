using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("Level01");
    }

    public void Exit()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }
}
