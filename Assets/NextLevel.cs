using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public GameObject flEv, slEv, tlEv;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if( SceneManager.GetActiveScene().name == "Introduction")
            {
                Instantiate(flEv, transform.position, Quaternion.identity);
            }else if (SceneManager.GetActiveScene().name == "Level1")
            {
                Instantiate(slEv, transform.position, Quaternion.identity);
            }else if (SceneManager.GetActiveScene().name == "Level2")
            {
                Instantiate(tlEv, transform.position, Quaternion.identity);
            }
        }
    }




}
