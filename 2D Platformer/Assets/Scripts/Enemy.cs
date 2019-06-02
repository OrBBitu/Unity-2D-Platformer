using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 100;
    public int killscore, minscore; // scorul pentru monstru, scorul minim la care poate ajunge monstrul

    public GameObject deathEffect;
    public Transform target; // pe cine sa urmareasca inamicul 
    public float minDistance;
    public float moveSpeed; // viteza cu care se poate misca monstrul
    public float jumpForce; // forta cu care sare un jumper
    private float range; 
    Vector3 targetPos; // pozitia target-ului

    public AudioClip squid_death, crab_death, jumper_death;
    public AudioSource source;

    private void Start()
    {
        if(gameObject.name.Contains("Jumper"))InvokeRepeating("Jump", 2.0f, 1.5f); // daca este jumper, inamicul va sari din 1,5 in 1,5 secunde
        InvokeRepeating("Substract", 0f, 3f);  // scade din scorul asociat inamicului la fiecare 3 secunde
        if (gameObject.name.Contains("Jumper")) source.clip = jumper_death; //
        if (gameObject.name.Contains("Crab")) source.clip = crab_death;    // Diferite sunete pentru fiecare tip de monstru.
        if (gameObject.name.Contains("Squid")) source.clip = squid_death; //
    }

    void Update()
    {
        if (GameObject.Find("Player")) // daca Player-ul este in viata...
        {
            target = GameObject.FindWithTag("Player").transform; // ...el devine tinta.




            range = Vector2.Distance(transform.position, target.position);
            targetPos = new Vector3(target.position.x,
                                            this.transform.position.y,   // limitez pe axa Y 
                                            target.position.z);

            transform.LookAt(targetPos);
            //sau direct transform.LookAt(target.position) si se uita dupa mine pe ambele axe
            transform.Rotate(new Vector3(0, 90, 0), Space.Self);

            if (range < minDistance) // daca distanta la care se afla Player-ul este mai mica decat distanta minima
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 0, 0), moveSpeed * Time.deltaTime); // monstrul incepe sa se miste in fata.
            }
        }
    }

    /// <summary>
    /// Functie care scade din viata unui monstru.
    /// </summary>
    /// <param name="damage"> Valoare damage-ului primit. </param>
    public void TakeDamage (int damage)
    {
        hp -= damage;

        if(hp <= 0) /// monstrul va muri
        {
            AudioSource.PlayClipAtPoint(source.clip, transform.position);
            Die();
        }
    }

    void Die()
    {
        //Debug.Log(killscore);
        ScoreScript.scoreValue += killscore; // se adauga scorul pentru monstrul omorat.
        Instantiate(deathEffect, transform.position, Quaternion.identity); // se reda efectul "deathEffect".
        Destroy(gameObject); // se distruge monstrul.
    }

    /// <summary>
    /// Arunca obiectul in sus cu puterea variabilei "jumpForce".
    /// </summary>
    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.up * jumpForce;
    }

    /// <summary>
    /// Scade 10 daca scorul curent e mai mare decat scorul minim.
    /// </summary>
    void Substract()
    {
        if (killscore > minscore) killscore -= 10;
    }

}
