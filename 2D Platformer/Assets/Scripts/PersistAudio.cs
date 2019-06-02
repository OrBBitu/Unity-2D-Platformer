using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// Fiind statica, instanta obiectului va fi mereu unica.
    /// </summary>
    private static PersistAudio instance = null;
    public static PersistAudio Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// Awake() se apeleaza la fiecare creare a obiectului.
    /// Daca exista deja o instanta, distruge instanta creata acum, altfel creeaza una.
    /// </summary>
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject); // Previne distrugerea obiectului la incarcarea unei scene noi.
    }
}