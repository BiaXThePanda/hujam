using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShop : MonoBehaviour
{
    public int healthPrice;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Heal()
    {
       if(healthPrice <= player.gold)
        {
            player.DecreaseGold(50);
        }
    }




    public void CloseCanvas()
    {
        Debug.Log("kapatildi");
        Destroy(gameObject);
    }





    
}
