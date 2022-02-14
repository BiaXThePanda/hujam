using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Health : MonoBehaviour
{

    public bool canInteract;
    
    private AudioSource audSrc;
    public AudioClip sfx;

    Player player;
    public GameObject E;

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

                if (30 <= player.gold)
                {
                    audSrc.PlayOneShot(sfx);
                    player.DecreaseGold(30);
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
            E.SetActive(true);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
            E.SetActive(false);

        }
    }
}
