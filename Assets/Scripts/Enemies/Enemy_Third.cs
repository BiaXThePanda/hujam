using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Third : Enemy
{
    //BOMBERRRRRR
    public float prepareDuration;
    public float stunPlayerDuration;
    private bool attacked = false;
    public float damageRadius;
    // Start is called before the first frame update
    void Start()
    {
        damageRadius = range * 1.5f;
    }


    // Update is called once per frame
    void Update()
    {

        if (canFollow)
        {

            if (Vector2.Distance(transform.position, target.transform.position) > innerRange)
            {

                Follow();
            }
        }



        if (Vector2.Distance(transform.position, target.transform.position) <= innerRange)
        {
            if (!attacked)
            {
                Attack();
                Debug.Log("hazirlaniyor");
            }
          

        }
    }




    protected override void Attack()
    {
        base.Attack();
        
        attacked = true;
        //animator.SetTrigger("Attack");
        StartCoroutine(Attacking(prepareDuration, stunPlayerDuration));
        
    }


    IEnumerator Attacking(float prepareDuration,float stunTime)
    {
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        yield return new WaitForSeconds(prepareDuration);
        animator.SetTrigger("Boom");
        player.GetComponent<Player>().GetDamage(damage, true);
        player.GetComponent<Rigidbody2D>().AddForce((player.transform.position-transform.position)*300);
        if(player.transform.position.x-transform.position.x < 0 && player.transform.localScale.x != player.GetComponent<Player>().startLocalScaleX)
        {
            Debug.Log("1");
            player.transform.localScale = new Vector2(player.GetComponent<Player>().startLocalScaleX, player.transform.localScale.y);
            player.GetComponent<Player>().isFacingRight = false;
        }
        else if(player.transform.position.x - transform.position.x > 0 && player.transform.localScale.x == player.GetComponent<Player>().startLocalScaleX)
        {
            Debug.Log("2");

            player.transform.localScale = new Vector2(-player.GetComponent<Player>().startLocalScaleX, player.transform.localScale.y);
            player.GetComponent<Player>().isFacingRight = true;

        }
        
        StartCoroutine(DestroyEnemyA());
    }
    IEnumerator DestroyEnemyA()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
