using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAreaa : MonoBehaviour
{
    // Start is called before the first frame update

    bool isPlaying;
    private AudioSource audSrc;

    private void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!isPlaying)
            {
                audSrc.Play();
                isPlaying = true;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audSrc.Stop();
            isPlaying = false;
        }
    }
}
