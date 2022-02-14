using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Back : MonoBehaviour
{

    public bool canBuy;
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    Player player;
    public bool canInteract;
    private AudioSource audSrc;
    public AudioClip sfx;
    public Color color;
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

                if (player.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf && 50 <= player.gold)
                {
                    player.popoRadius *= 1.3f;
                    Debug.Log("zort");
                    audSrc.PlayOneShot(sfx);
                    player.DecreaseGold(50);
                }
                else if (player.transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf && 50 <= player.gold)
                {
                    //UPGRADELER
                    player.transform.GetChild(1).transform.GetChild(1).GetComponent<SpriteRenderer>().color = color;
                    audSrc.PlayOneShot(sfx);
                    player.DecreaseGold(50);

                }
                else if (player.transform.GetChild(1).transform.GetChild(2).gameObject.activeSelf && 50 <= player.gold)
                {
                    //UPGRADELER
                    player.jumpForce *= 1.4f;
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
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canInteract = false;
        }
    }

    public void UpdateShop()
    {
        if (player.transform.GetChild(1).transform.GetChild(0).gameObject.activeSelf)
        {
            spriteRenderer.sprite = sprites[0];
            canBuy = true;
        }else if (player.transform.GetChild(1).transform.GetChild(1).gameObject.activeSelf)
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
