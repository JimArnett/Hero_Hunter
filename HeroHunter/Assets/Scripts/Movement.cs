using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    bool onGround;
    // player walking animation
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // sets rb to rigidbody 2d component
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // checks if player presses left arrow key
        {
            transform.Translate(-4 * Time.deltaTime, 0, 0); // moves player to the left
            anim.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.RightArrow)) // checks if oplayer presses right arrow key
        {
            transform.Translate(4 * Time.deltaTime, 0, 0); // moves player to the right
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("idle", true);
        }

        if (onGround == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) // checks if player presss up arrow key
            {
             
                rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse); // makes player jump
                onGround = false;

            }
        }



    }

    private void OnTriggerEnter2D(Collider2D other) //checks collision of object with payer
    {
        if (other.tag == "Ground")
        {
            onGround = true;
        }

    }

}
