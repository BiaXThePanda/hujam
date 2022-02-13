using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fourth : Enemy
{

    public bool isRoaming = true;
    public float targetX;
    public float distance;
    public float leftToAttack = 3f;
    private bool isAttacking;
    private bool isHitting;
    public float coolDownTime;
    private float coolDown;

    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = 0;
        targetX = transform.position.x + distance;
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,Vector2.down*innerRange);
        if(isRoaming == true)
        {
            Debug.LogError("Dolaniyor");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(targetX,transform.position.y),speed*Time.deltaTime);
        }
        if(transform.position.x == targetX)
        {
            targetX = -targetX;
        }
        leftToAttack -= Time.deltaTime;
        if(leftToAttack <= 0)
        {
            isRoaming = false;
            leftToAttack = 10;
            Attack();
        }
        if (isAttacking)
        {
            isHitting = Physics2D.OverlapCircle(transform.position, innerRange, playerLayer);
            if (isHitting)
            {
                coolDown -= Time.deltaTime;
                if(coolDown <= 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetDamage(1);
                    coolDown = coolDownTime;
                }
               
            }
        }
    }




    protected override void Attack()
    {
        Debug.Log("Attack");
        base.Attack();
        animator.SetTrigger("Attack");
        Invoke("Hit", 1f);
       


    }

    protected override void Die()
    {
        base.Die();
        isRoaming = false;
    }

    public void Hit()
    {
        isAttacking = true;
    }


    public void EndAttack()
    {

        Debug.Log("EndAttack"); 
        leftToAttack = Random.Range(3f, 6f);
        isAttacking = false;
        isRoaming = true;
        coolDown = coolDownTime;
    }
}
