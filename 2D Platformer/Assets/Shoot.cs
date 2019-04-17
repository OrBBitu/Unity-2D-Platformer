using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame

    private void Start()
    {
        InvokeRepeating("Shot", 2.0f, 1f);
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
