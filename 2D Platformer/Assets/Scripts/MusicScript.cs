using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioClip music_clip; // Melodia ce trebuie redata.
    public AudioSource music_source; //Sursa de unde se aude melodia.
    
    // Start is called before the first frame update
    void Start()
    {
        music_source.clip = music_clip; //Sursa primeste melodia.
        music_source.Play(); //Se reda melodia, avand ca origine sursa declarata mai sus.

        DontDestroyOnLoad(this.gameObject); //Previne distrugerea la schimbarea scenei.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
