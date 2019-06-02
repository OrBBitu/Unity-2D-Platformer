using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject warpEffect;
    Vector3 startPos; // pozitia de start

    private void Start()
    {
        HealthSystem.health = 5; // se initializeaza viata cu 5
        startPos = gameObject.transform.position; // pozitia Player-ului in momentul de start este tinuta in variabila startpos. 
    }

    private void Update()
    {
        //Daca se apasa tasta corespunzatoare comenzii "Exit" (tasta "P"), se revine la meniul principal.
        if (Input.GetButtonDown("Exit"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    /// <summary>
    /// Functie care detecteaza coliziunea cu un obiect.
    /// </summary>
    /// <param name="collision"> Retine informatii despre obiectul care a facut coliziune cu player-ul. </param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy enemy = collision.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Enemy") // Daca obiectul este un inamic...
        {
            //Destroy(gameObject); // Player-ul este distrus.
            Reposition();
            Instantiate(deathEffect, transform.position, Quaternion.identity); // Se produce animatia "deathEffect".
        }
    }

    /// <summary>
    /// Functie care detecteaza daca Player-ul s-a intalnit cu un "Trigger".
    /// </summary>
    /// <param name="collision"> Retine informatii despre "Trigger"-ul intalnit. </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Warpgate") // daca trigger-ul este un warpgate
        {
            Instantiate(warpEffect, transform.position, Quaternion.identity); // Se produce animatia "warpEffect".
            Destroy(gameObject); // Player-ul este distrus.
        }
    }

    /// <summary>
    /// Functie care scade o inima din viata Player-ului. Daca acesta ajunge la 0 inimi, este repozitionat.
    /// </summary>
    public void TakeDamage()
    {

        HealthSystem.health -= 1; 
        if (HealthSystem.health <= 0)
        {
            Reposition();
        }

    }

    /// <summary>
    /// Functie care distruge Player-ul si reda animatie "deathEffect".
    /// </summary>
    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    /// <summary>
    /// Functie care reseteaza viata la 5, scade scorul cu 500 de puncte si repozitioneaza Player-ul la inceputul nivelului.
    /// </summary>
    public void Reposition()
    {
        HealthSystem.health = 5;
        ScoreScript.scoreValue -= 500;
        gameObject.transform.position = startPos;
    }

}
