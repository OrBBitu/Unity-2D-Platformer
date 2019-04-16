using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deathEffect;

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

}
