using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public Collider2D box, tilemap;
    public GameObject raypoint;
    public Transform firepoint;

    float currX, currY, currZ;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    Vector3 firepoint_stand = new Vector3(0.163F, 0.0272F, 0.00994F);
    Vector3 firepoint_crouch = new Vector3(0.163F, -0.06F, 0.00994F);

    bool checkCeiling;

    public float runSpeed = 40f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(crouch == true) /// daca player-ul este ghemuit
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * (runSpeed/2); // se va misca de doua ori mai incet
        } else horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Debug.Log(runSpeed);

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); /// aplica modul pe variabila de miscare orizontala, care poate fi si cu minus

        if (Input.GetButtonDown("Jump")) /// daca se inregistreaza butonul de saritura ca fiind apasat...
        {
            jump = true; /// ...caracterul este in saritura...
            animator.SetBool("isJumping", true); /// ...si parametrul din animator ce arata ca este in saritura devine true.
        }

        if (Input.GetButtonDown("Crouch")) /// daca se inregistreaza butonul de ghemuit ca fiind apasat...
        {
            currX = firepoint.transform.position.x; ///  
            currY = firepoint.transform.position.y; ///  retin coordonatele punctului de tragere
            currZ = firepoint.transform.position.z; ///

            if (crouch == false) firepoint.transform.position = new Vector3(currX, currY - 4 * 0.0872F, currZ); /// daca urmeaza sa se ghemuiasca, mut punctul de tragere mai jos.

            crouch = true; /// marchez ca este ghemuit
            animator.SetBool("isCrouching", true); /// marchez in animator ca este ghemuit
            box.enabled = false; /// dezactivez collider-ul de sus

        }
        else if (Input.GetButtonDown("Stand")) /// daca se inregistreaza butonul de ridicare ca fiind apasat...
        {

            currX = firepoint.transform.position.x; ///
            currY = firepoint.transform.position.y; /// retin coordonatele punctului de tragere
            currZ = firepoint.transform.position.z; /// 

            //Debug.DrawRay(raypoint.transform.position, Vector3.up, Color.green, 0.1F);

            // trasez o dunga din capul player-ului ca sa vad daca ma pot ridica...
            if (Physics2D.Raycast(raypoint.transform.position, Vector3.up, 0.1F)) // daca atinge ceva inseamna ca nu se poate ridica
            {
                checkCeiling = true; // am "tavan" deasupra, un obstacol
                crouch = true; // sunt inca ghemuit
                animator.SetBool("isCrouching", true); // animatorul stie ca inca sunt ghemuit
                box.enabled = false; // ramane dezactivat collider-ul de sus
            }
            else // nu am nimic deasupra capului
            {
                // daca eram ghemuit, atunci rectific modificarea la punctul de tragere, revine unde era inainte, adica sus
                if (crouch == true) firepoint.transform.position = new Vector3(currX, currY + 4 * 0.0872F, currZ);

                checkCeiling = false; // nu am obstacol deasupra
                crouch = false; // nu mai sunt ghemuit
                animator.SetBool("isCrouching", false); // animatorul stie ca nu mai sunt ghemuit
                box.enabled = true; // collider-ul de sus revine
            }


        }
    }

    /*public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
    }*/

    /// <summary>
    /// Functie care detecteaza daca am aterizat pe o structura.
    /// </summary>
    /// <param name="collision"> Informatii despre obiectul pe care l-am atins. </param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Structure") // daca obiectul este o structura...
        {
            animator.SetBool("isJumping", false); // animatorul stie ca nu mai sunt in saritura
        }
        
    }

    void FixedUpdate()
    {
        // Move
        controller.Move(horizontalMove * Time.fixedDeltaTime, !(box.enabled), jump); // master script-ul de control 
        jump = false;
    }
}
