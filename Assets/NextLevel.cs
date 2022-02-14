using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public GameObject flEv, slEv, tlEv;
    public GameObject canvasEnding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if( SceneManager.GetActiveScene().name == "Introduction")
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().evolveGot < 3)
                {
                    Instantiate(flEv, transform.position, Quaternion.identity);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().evolveGot++;
                }
                
            }else if (SceneManager.GetActiveScene().name == "Level1")
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().evolveGot < 3)
                {
                    Instantiate(slEv, transform.position, Quaternion.identity);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().evolveGot++;
                }

            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().evolveGot < 3)
                {
                    Instantiate(tlEv, transform.position, Quaternion.identity);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().evolveGot++;
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                Instantiate(canvasEnding, transform.position, Quaternion.identity);
            }
        }
    }




}
