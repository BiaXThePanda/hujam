using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ToShop : MonoBehaviour
{
    public Transform destination;
    public CinemachineFramingTransposer cm;

    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = destination.position;
            if(destination.transform.position.y > transform.position.y)
            {
                cm.m_ScreenY = 0.5f;
            }
            else
            {
                cm.m_ScreenY = 0.345f;


            }
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
