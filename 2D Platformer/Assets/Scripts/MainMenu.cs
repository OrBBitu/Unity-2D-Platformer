using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script utilitar pentru functionalitatea butoanelor din cele doua meniuri (start/endgame).
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Functie care seteaza scorul pe 0, si incarca primul nivel al jocului. Apelata la apasarea butonului "Play" din meniul principal.
    /// </summary>
    public void Play()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("Level01");
    }

    /// <summary>
    /// Functie care inchide aplicatia. Apelata la apasarea butonului "Exit" din meniul principal.
    /// </summary>
    public void Exit()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }

    /// <summary>
    /// Functie care revine la meniul principal. Apelata la apasarea butonului "Back to main menu" din meniul de final.
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
