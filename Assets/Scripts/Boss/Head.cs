using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float tossAmount;
    public bool isRushingInh;
    public bool isFiringInh;

    public float headRadius;
    public LayerMask player;

    public float coolDownTime;
    public float coolDownLeft;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position,Vector2.left*headRadius,Color.green);
        isRushingInh = transform.parent.GetComponent<Boss>().isRushing;
        isFiringInh = transform.parent.GetComponent<Boss>().isFiring;
        if (isRushingInh)
        {
            coolDownLeft -= Time.deltaTime;
            if(coolDownLeft<= 0)
            {
                if (Physics2D.OverlapCircle(transform.position, headRadius, player))
                {
                    GameObject playerObj = Physics2D.OverlapCircle(transform.position, headRadius, player).gameObject;
                    playerObj.transform.GetComponent<Player>().GetDamage(25, true);
                    playerObj.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2((playerObj.transform.position.x - transform.position.x) * tossAmount, tossAmount));
                    coolDownLeft = coolDownTime;
                }
            }
            


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {/*
        if(collision.gameObject.tag == "Player")
        {
            
            if (isRushingInh)
            {
                Debug.Log("adas");
                collision.transform.GetComponent<Player>().GetDamage(25,true);
                collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2((collision.transform.position.x-transform.position.x)* tossAmount, tossAmount));
            }
        }*/
    }
        
}
