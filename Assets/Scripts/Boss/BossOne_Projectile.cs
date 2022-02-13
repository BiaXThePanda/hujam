using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOne_Projectile : MonoBehaviour
{

    public float radius;
    public LayerMask playerLayer;
    public float tossAmount;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        Debug.DrawRay(transform.position,new Vector2(transform.position.x+radius,transform.position.y));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            
            if (Physics2D.OverlapCircle(transform.position, radius, playerLayer))
            {
                Debug.Log("PATLADI");
                GameObject player = Physics2D.OverlapCircle(transform.position, radius, playerLayer).gameObject;
                player.transform.GetComponent<Player>().GetDamage(damage, false);
                player.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2((player.transform.position.x-transform.position.x) * tossAmount, tossAmount/5));
               
            }
            Destroy(gameObject);
        }
    }


    private void Explosion()
    {

    }
}
