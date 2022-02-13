using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Second : Enemy
{

    //Movement
    Rigidbody2D rb;
    public bool facingRight;
    public GameObject platform;
   
    //GroundCheck
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    public float startLocalScaleX;
    // Start is called before the first frame update
    void Start()
    {
        startLocalScaleX = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(groundCheck.position, Vector2.down,groundCheckRadius);
        Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, Color.green);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i].transform.gameObject.layer == 6)
            {
                platform = hits[i].transform.gameObject;
                break;
            }
            if(i == hits.Length - 1)
            {
                FlipNPC();
            }

        }



        if (facingRight)
        {
            rb.velocity = new Vector2(speed,rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        

    }


    private void FlipNPC()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack();
            Vector2 lastSpeed = new Vector2(collision.transform.GetComponent<Player>().movement, collision.transform.GetComponent<Rigidbody2D>().velocity.y);
            Debug.Log(lastSpeed.x);
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (lastSpeed.x > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2,1)*300);
            }
            else if(lastSpeed.x<0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 1)* 300);
            }else if(lastSpeed.x == 0)
            {
                Debug.Log("duruyor");
                float posx = collision.transform.position.x - transform.position.x;
                if(posx >= 0)
                {
                    Debug.Log("SaðAT");
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 1) * 300);
                }
                else
                {
                    Debug.Log("SolAT");

                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 1) * 300);

                }
            }
            
           
        }
    }

    protected override void Attack()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetDamage(damage,true);

    }
}
