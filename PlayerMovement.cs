using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Movement
    public float speed;
    public float jump;
    public float maxHorizVelocity;
    public float horizVelocity;
    public int fireflyCount;
    
    public bool facingRight;

    //Grounded?
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        fireflyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown (KeyCode.Space))
        {
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2
                    (GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        //Lateral motion
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            facingRight = false;
            if (horizVelocity >= maxHorizVelocity)
                horizVelocity -= speed;
            else
                horizVelocity = -maxHorizVelocity;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            facingRight = true;
            if (horizVelocity <= maxHorizVelocity)
                horizVelocity += speed;
            else
                horizVelocity = maxHorizVelocity;
        }
        else
            horizVelocity = 0;

        GetComponent<Rigidbody2D>().velocity = new
            Vector2(horizVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ground check
        if (collision.gameObject.name == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Firefly")
        {
            fireflyCount++;
        }
    }
}
