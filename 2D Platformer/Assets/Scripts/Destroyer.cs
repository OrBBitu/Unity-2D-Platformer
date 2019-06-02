using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);  /// Distruge obiectul la 5 secunde dupa ce a fost creat.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
