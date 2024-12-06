using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpPower = 7f;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private Transform groundChecker;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded())
            {
                Jump();
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    bool Grounded()
    {
        //Laser Length
        float laserLength = 1f;
        //Start point of the laser
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;

        //Show Laser for Debugging
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, laserLength, Ground);
        if (hit.collider != null)
        {
            return true;
        }
        return false;


    }

    void Jump()
    {
        //Jump Code (Uses Raycast to make sure jump is only use once)
        if (!Grounded())
        { return; }
        else
        { rb.velocity = new Vector2(rb.velocity.x, jumpPower); }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Increase score based on collison 
        if (collision.gameObject.CompareTag("GoodItem"))
        {
            score += 1;
        }
        if (collision.gameObject.CompareTag("BadItem"))
        {
            if (score >= 1)
            {
                score -= 1;
            }
        }
    }





}
