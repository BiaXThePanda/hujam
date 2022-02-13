using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demirci : MonoBehaviour
{


    public bool canInteract;
    public GameObject canvasDemirci;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pazar");
            Instantiate(canvasDemirci,transform.position,Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
