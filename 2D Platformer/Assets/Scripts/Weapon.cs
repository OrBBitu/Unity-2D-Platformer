using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint; // originea proiectilului.
    public GameObject bulletPrefab; // proiectilul.

    public AudioClip shoot;
    public AudioSource source;

    // Update is called once per frame

    private void Start()
    {
        Ammunition.ammo = 5; // la inceput avem 5 gloante.
        InvokeRepeating("Generate", 1.0f, 2.0f); // generam unul nou la fiecare secunda.
        source.clip = shoot;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // daca se apasa butonul de tragere.
        {
            Shoot();
        }
    }

    void Shoot()
    {

        // daca am gloante cu care pot trage...
        if(Ammunition.ammo >= 1)
        {
            source.Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Ammunition.ammo -= 1;
        }

    }

    /// <summary>
    /// Functie care genereaza un glont.
    /// </summary>
    void Generate()
    {
        if(Ammunition.ammo <= 4)Ammunition.ammo += 1;
    }

}
