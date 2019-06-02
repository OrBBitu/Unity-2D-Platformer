using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clasa care se ocupa de gloante.
/// </summary>
public class Ammunition : MonoBehaviour
{
    public static int ammo; // numarul curent de gloante.
    public int maxAmmo; // numarul maxim de gloante.

    public Image[] bullets; // vector de imagini.
    public Sprite bullet; // imagine cu glontul.
    public Sprite emptySprite; // imaginea goala.

    private void Update()
    {

        if (ammo > maxAmmo) // daca am mai multe gloante decat maximul permis, pastrez doar numarul maxim.
        {
            ammo = maxAmmo;
        }

        for (int i = 0; i < bullets.Length; i++) // verific mereu vectorul sa vad cate gloante am.
        {

            if (i < ammo) // daca am, completez vectorul cu imagine de glont.
            {
                bullets[i].sprite = bullet;
            }
            else // altfel sterg imaginile daca gloantele de pe acele pozitii au fost trase.
            {
                bullets[i].sprite = emptySprite;
            }

            if (i < maxAmmo) // gloantele care trec peste limita sunt ignorate oricum.
            {
                bullets[i].enabled = true;
            }
            else
            {
                bullets[i].enabled = false;
            }
        }
    }

}
