﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue = 0;
    private TextMeshProUGUI score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>(); // tine componenta 
    }

    void Update()
    {
        score.text = "Score : " + scoreValue; // acceseaza field-ul de text pentru a il updata la fiecare frame.
    }
}
