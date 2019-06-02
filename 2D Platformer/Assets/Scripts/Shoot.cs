using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script utilitar pentru a permite ca inamicul sa traga automat la fiecare secunda.
/// </summary>
public class Shoot : MonoBehaviour
{
    public Transform firePoint; // locatia de unde pleaca proiectilul.
    public GameObject bulletPrefab; // proiectilul in sine.

    // Update is called once per frame

    private void Start()
    {
        InvokeRepeating("Shot", 3.0f, 1f); // dupa 3 secunde, incepe sa lanseze un proiectil la fiecare secunda.
    }

    void Update()
    {
        
    }

    void Shot()
    {

        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
