﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            //Scene currentScene = SceneManager.GetActiveScene();

            Invoke("ChangeLevel", 1.0f);
        }
    }

    void ChangeLevel()
    {
        SceneManager.LoadScene("Level02");
    }

}
