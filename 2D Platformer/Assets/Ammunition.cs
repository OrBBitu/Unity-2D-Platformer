using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammunition : MonoBehaviour
{
    public static int ammo;
    public int maxAmmo;

    public Image[] bullets;
    public Sprite bullet;
    public Sprite emptyHeart;

    private void Update()
    {

        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        for (int i = 0; i < bullets.Length; i++)
        {

            if (i < ammo)
            {
                bullets[i].sprite = bullet;
            }
            else
            {
                bullets[i].sprite = emptyHeart;
            }

            if (i < maxAmmo)
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
