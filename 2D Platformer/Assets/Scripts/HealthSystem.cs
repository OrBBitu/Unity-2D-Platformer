using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clasa care se ocupa de gestiunea inimilor.
/// </summary>
public class HealthSystem : MonoBehaviour
{
    public static int health; // numarul curent de inimi.
    public int numOfHearts; // numarul maxim de inimi.

    public Image[] hearts; // vector de inimi.
    public Sprite fullHeart; // imagine cu inima plina.
    public Sprite emptyHeart; // imagine cu inima goala.

    private void Update()
    {

        if (health > numOfHearts) // daca avem mai multe inimi decat este permis, le ignoram.
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) // verificam mereu daca...
        {

            if(i < health) // avem viata, atunci completam cu inimi.
            {
                hearts[i].sprite = fullHeart;
            } else // altfel, completam cu inimi goale.
            {
                hearts[i].sprite = emptyHeart;
            }

            if ( i < numOfHearts) // luam in considerare doar inimile care trebuie.
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        } 
    }

}
