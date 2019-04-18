﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 100;

    public GameObject deathEffect;
    public Transform target;
    public float minDistance;
    public float moveSpeed;
    private float range;
    Vector3 targetPos;

    private void Start()
    {
        if(gameObject.name.Contains("Jumper"))InvokeRepeating("Jump", 2.0f, 1.5f);
    }

    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;

        range = Vector2.Distance(transform.position, target.position);
        targetPos = new Vector3(target.position.x,
                                        this.transform.position.y,   // limitez pe axa Y 
                                        target.position.z);        

        transform.LookAt(targetPos);
        //sau direct transform.LookAt(target.position) si se uita dupa mine pe ambele axe
        transform.Rotate(new Vector3(0, 90, 0), Space.Self);

        if (range < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 0, 0), moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage (int damage)
    {
        hp -= damage;

        if(hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.up * 7;
    }

}
