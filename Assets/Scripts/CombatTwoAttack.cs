using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTwoAttack : MonoBehaviour
{


    public float radius;
    public LayerMask enemyLayer;

    private void Start()
    {
        if (Physics2D.OverlapCircle(transform.position, radius, enemyLayer)){
            GameObject enemy = Physics2D.OverlapCircle(transform.position, radius, enemyLayer).gameObject;
            enemy.GetComponent<Enemy>().GetDamage(100);
        }

    }
    public void DestroySelf()
    {
        transform.parent = null;
        Destroy(gameObject);
    }

}
