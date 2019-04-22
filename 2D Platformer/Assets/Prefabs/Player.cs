using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject warpEffect;

    // Update is called once per frame

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

}
