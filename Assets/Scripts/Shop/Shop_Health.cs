using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Health : MonoBehaviour
{

    public bool canInteract;
    
    private AudioSource audSrc;
    public AudioClip sfx;

    Player player;
    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                if (50 <= player.gold)
                {
                    audSrc.PlayOneShot(sfx);
                    player.DecreaseGold(50);
                    player.IncreaseHealth();
                }

            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
        }
    }
}
