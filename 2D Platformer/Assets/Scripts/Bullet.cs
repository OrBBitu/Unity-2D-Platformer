using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f; // viteza glontului
    public int damage = 40; // daunele pe care le cauzeaza
    public Rigidbody2D rb; // variabila care tine corpul rigid al glontului pentru a putea fi propulsat
    public GameObject impactEffect; // efect de impact cu structuri sau alte obiecte
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed; // cand este instantiat se propulseaza automat
        Destroy(gameObject, 3f); // dupa 3 secunde se distruge pentru a preveni aglomerarea de asset-uri
    }

    /// <summary>
    /// Functie pentru a detecta coliziuni cu alte obiecte.
    /// </summary>
    /// <param name="hitInfo"> Tine informatii despre obiectul lovit. </param>
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Player player = hitInfo.GetComponent<Player>();

        if (enemy) // daca a lovit un inamic.
        {
            enemy.TakeDamage(damage); // scade "damage" din viata unui monstru.
        }

        if(player) // daca a lovit un player.
        {
            player.TakeDamage(); // scade o inima din viata player-ului.
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);

    }

}
