using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Combat : MonoBehaviour
{
    public bool canBuy;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    Player player;
    public bool canInteract;
    private AudioSource audSrc;
    public AudioClip sfx;
    public GameObject E;
    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy == true)
        {
            if (canInteract)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (player.transform.GetChild(2).transform.GetChild(0).gameObject.activeSelf && 50 <= player.gold)
                    {
                        //UPGRADELER
                        player.jumpForce *= 1.05f;
                        player.speed *= 1.05f;
                        audSrc.PlayOneShot(sfx);
                        player.DecreaseGold(50);
                    }
                    else if (player.transform.GetChild(2).transform.GetChild(1).gameObject.activeSelf && 50 <= player.gold)
                    {
                        //UPGRADELER
                        player.transform.GetComponent<CheckEvolves>().combatTwoMax *= 0.8f;
                        audSrc.PlayOneShot(sfx);
                        player.DecreaseGold(50);

                    }
                    else if (player.transform.GetChild(2).transform.GetChild(2).gameObject.activeSelf && 50 <= player.gold)
                    {
                        player.wallSlidingCountdown = 0.01f;
                        audSrc.PlayOneShot(sfx);
                        player.DecreaseGold(50);

                    }

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

    public void UpdateShop()
    {
        if (player.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf)
        {
            spriteRenderer.sprite = sprites[0];
            canBuy = true;
        }
        else if (player.transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf)
        {
            spriteRenderer.sprite = sprites[0];
            canBuy = true;

        }
        else if (player.transform.GetChild(1).transform.GetChild(2).gameObject.activeSelf)
        {
            spriteRenderer.sprite = sprites[0];
            canBuy = true;

        }
        else
        {

        }
    }
}
