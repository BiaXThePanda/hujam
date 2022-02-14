using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToShop : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = destination.position;
            GameObject[] shops = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject shop in shops)
            {
                if (shop.GetComponent<Shop_Head>()!=null)
                {
                    shop.GetComponent<Shop_Head>().UpdateShop();
                }else if (shop.GetComponent<Shop_Back>() != null)
                {
                    shop.GetComponent<Shop_Back>().UpdateShop();
                }
                else if (shop.GetComponent<Shop_Combat>() != null)
                {
                    shop.GetComponent<Shop_Combat>().UpdateShop();
                }

            }
        }
    }
}
