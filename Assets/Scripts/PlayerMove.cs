using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpSpeed = 5f;

    Rigidbody2D rb2d;
    Animator anim;

    int countJump = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (countJump <= 1)
            {
                rb2d.AddForce(new Vector2(0, jumpSpeed));
                anim.Play("MarioMove");
                countJump++;
            }
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddForce(new Vector2(moveSpeed, 0f));
            anim.Play("MarioMove");
            transform.localEulerAngles = Vector3.zero;
        } 
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb2d.AddForce(new Vector2(-moveSpeed, 0f));
                anim.Play("MarioMove");
                transform.localEulerAngles = new Vector3(0, 180f, 0);
            }
            else
            {
                anim.Play("MarioIdle");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Flower"))
        {
            countJump = 1;
        }
        if (collision.gameObject.tag.Equals("Obstacles"))
        {
            countJump = 1;
        }
        if (collision.gameObject.tag.Equals("Land"))
        {
            countJump = 0;
        }

    }
}
