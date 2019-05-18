using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject warpEffect;
    Vector3 startPos;
    //public int health;

    private void Start()
    {
        HealthSystem.health = 5;
        startPos = gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy enemy = collision.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Enemy") 
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Warpgate")
        {
            Instantiate(warpEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {

        HealthSystem.health -= 1; 
        if (HealthSystem.health <= 0)
        {
            Reposition();
        }

    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Level01");
    }

    public void Reposition()
    {
        HealthSystem.health = 5;
        ScoreScript.scoreValue -= 500;
        gameObject.transform.position = startPos;
    }

}
