using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioClip shoot;
    public AudioSource source;

    // Update is called once per frame

    private void Start()
    {
        Ammunition.ammo = 5;
        InvokeRepeating("Generate", 1.0f, 2.0f);
        source.clip = shoot;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        //shooting logic
        if(Ammunition.ammo >= 1)
        {
            source.Play();
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Ammunition.ammo -= 1;
        }

    }

    void Generate()
    {
        if(Ammunition.ammo <= 4)Ammunition.ammo += 1;
    }

}
