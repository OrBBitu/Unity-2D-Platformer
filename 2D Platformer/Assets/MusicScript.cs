using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioClip music_clip;
    public AudioSource music_source;
    
    // Start is called before the first frame update
    void Start()
    {
        music_source.clip = music_clip;
        music_source.Play();

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
