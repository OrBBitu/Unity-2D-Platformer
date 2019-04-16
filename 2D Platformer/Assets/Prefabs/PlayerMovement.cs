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
        if(crouch == true)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * (runSpeed/2);
        } else horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        //Debug.Log(runSpeed);

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            currX = firepoint.transform.position.x;
            currY = firepoint.transform.position.y;
            currZ = firepoint.transform.position.z;

            if (crouch == false) firepoint.transform.position = new Vector3(currX, currY - 4 * 0.0872F, currZ);

            crouch = true;
            animator.SetBool("isCrouching", true);
            box.enabled = false;

        }
        else if (Input.GetButtonDown("Stand"))
        {

            currX = firepoint.transform.position.x;
            currY = firepoint.transform.position.y;
            currZ = firepoint.transform.position.z;

            Debug.DrawRay(raypoint.transform.position, Vector3.up, Color.green, 0.1F);

            if (Physics2D.Raycast(raypoint.transform.position, Vector3.up, 0.1F)) // this checks your boolean AND the new boolean, defined above.
            {
                checkCeiling = true;
                crouch = true;
                animator.SetBool("isCrouching", true);
                box.enabled = false;
            }
            else
            {
                if (crouch == true) firepoint.transform.position = new Vector3(currX, currY + 4 * 0.0872F, currZ);

                checkCeiling = false;
                crouch = false;
                animator.SetBool("isCrouching", false);
                box.enabled = true;
            }


        }
    }

    /*public void OnLanding ()
    {
        animator.SetBool("isJumping", false);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.tag == "Structure")
        {
            animator.SetBool("isJumping", false);
        }
        
    }

    void FixedUpdate()
    {
        //Move
        controller.Move(horizontalMove * Time.fixedDeltaTime, !(box.enabled), jump);
        jump = false;
    }
}
