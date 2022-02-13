using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!collision.GetComponent<Player>().dontGetHitByProjectiles)
            {
                collision.GetComponent<Player>().GetDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
