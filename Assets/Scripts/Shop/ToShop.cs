using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToShop : MonoBehaviour
{
    public Transform destination;

    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = destination.position;
            GameObject[] shops = GameObject.FindGameObjectsWithTag("Shop");
            Debug.Log(shops.Length);
            foreach (GameObject shop in shops)
            {
                Debug.LogError(shop.name);
                if (shop.GetComponent<Shop_Head>()!=null)
                {
                    shop.GetComponent<Shop_Head>().UpdateShop();

                }
                if (shop.GetComponent<Shop_Back>() != null)
                {
                    shop.GetComponent<Shop_Back>().UpdateShop();
                }

                if (shop.GetComponent<Shop_Combat>() != null)
                {
                    shop.GetComponent<Shop_Combat>().UpdateShop();
                }

            }
        }
    }
}
