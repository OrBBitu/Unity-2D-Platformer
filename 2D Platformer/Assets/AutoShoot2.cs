using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    Random rnd = new Random();

    // Update is called once per frame

    private void Start()
    {
        //float rof = Random.Range(0.5f, 0.7f);
        InvokeRepeating("Shoot", 5.0f, 0.7f);
    }

    void Shoot()
    {

        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


    }
}
