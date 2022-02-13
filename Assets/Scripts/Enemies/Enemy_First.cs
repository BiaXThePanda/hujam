using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_First : Enemy
{

    public float coolDown;

    private float leftToCD;

    public GameObject projectile;

    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        leftToCD = coolDown;
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
            leftToCD -= Time.deltaTime;
            if (leftToCD <= 0 && !isDead)
            {
                Attack();
                leftToCD = coolDown;
            }

        }
    }




    protected override void Attack()
    {
        Vector2 lookDirection = target.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDirection.y,lookDirection.x)*Mathf.Rad2Deg;
        base.Attack();
        animator.SetTrigger("Attack");
        
        GameObject inst = Instantiate(projectile, transform.position, Quaternion.Euler(0,0,angle -180));
        inst.GetComponent<Projectile>().damage = damage;
        inst.GetComponent<Rigidbody2D>().velocity = ( new Vector2(target.transform.position.x, target.transform.position.y-0.5f) - new Vector2(transform.position.x, transform.position.y)) * projectileSpeed;
    }
}
