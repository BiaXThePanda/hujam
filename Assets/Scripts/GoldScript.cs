using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{

    public int amount;
    public float speed;
    public float range;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().gold += amount;
            Destroy(gameObject);

        }
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().canMagnetGolds)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Vector2.Distance(player.transform.position , transform.position)<=range && player.GetComponent<Player>().canMagnetGolds)
        {
            Debug.Log("playera yuruyo");
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
        }
    }
}
