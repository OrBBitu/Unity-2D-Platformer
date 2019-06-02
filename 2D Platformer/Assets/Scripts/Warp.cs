using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{

    int multiplier, bonus;
    string nextLevel;
    public AudioSource source;
    public AudioClip warp_sound;
    
    // Start is called before the first frame update
    void Start()
    {
        source.clip = warp_sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Functie care detecteaza o intalnire cu un trigger.
    /// </summary>
    /// <param name="col"> Retine informatii despre trigger-ul intalnit. </param>
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player") /// Trigger-ul este Player-ul.
        {
            //Scene currentScene = SceneManager.GetActiveScene();
            Debug.Log(HealthSystem.health);
            multiplier = HealthSystem.health; /// Pastreaza numarul de vieti.
            bonus = multiplier * 200;
            bonus = bonus / 2;
            ScoreScript.scoreValue += bonus; /// Adauga 200 pentru fiecare viata pastrata.

            //AudioSource.PlayClipAtPoint(source.clip, transform.position);
            source.Play();
            Invoke("ChangeLevel", 1.0f);  /// Schimba nivelul dupa 1 secunde.
        }
    }

    /// <summary>
    /// Schimba nivelul in scena imediat urmatoare.
    /// </summary>
    void ChangeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
