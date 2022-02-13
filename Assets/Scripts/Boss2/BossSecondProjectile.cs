using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSecondProjectile : MonoBehaviour
{

    public float radius;
    public LayerMask playerLayer;
    public float tossAmount;
    public float damage;
    private bool canFollow;

    public Vector2 directionHere;
    private float waitAmountHere;
    private BossSecond bossHere;
    public float forceHere;
    // Start is called before the first frame update
    void Start()
    {
        canFollow = false;
    }
    private void Update()
    {

        if(canFollow)
        {
            transform.Translate(directionHere * forceHere * Time.deltaTime);
        }
        Debug.DrawRay(transform.position, new Vector2(transform.position.x + radius, transform.position.y));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.layer == LayerMask.NameToLayer("Ground") || collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {

            if (collision.gameObject.tag=="Player")
            {
                Debug.Log("PATLADI");
                GameObject player = Physics2D.OverlapCircle(transform.position, radius, playerLayer).gameObject;
                player.transform.GetComponent<Player>().GetDamage(damage, false);
                player.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2((player.transform.position.x - transform.position.x) * tossAmount, tossAmount / 5));

            }

            Destroy(gameObject);
        }
    }


    public IEnumerator Shoot(Transform player, float force, float waitAmount, BossSecond boss)
    {
        yield return new WaitForSeconds(waitAmount);
        Vector2 direction = new Vector2(player.transform.position.x, player.transform.position.y - 0.5f) - new Vector2(transform.position.x,transform.position.y);
        directionHere = direction;
        canFollow = true;
        forceHere = force;
       //transform.position = Vector2.MoveTowards(transform.position,direction,force*Time.deltaTime);
       // GetComponent<Rigidbody2D>().AddForce((player.transform.position-transform.position)*force);
        waitAmountHere = waitAmount;
        bossHere = boss;
        
    }
}
