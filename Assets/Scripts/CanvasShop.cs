using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CloseCanvas()
    {
        Debug.Log("kapatildi");
        Destroy(gameObject);
    }
}
