using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic1 : MonoBehaviour
{

    public bool started;
    private AudioSource audSrc;
    public AudioClip loop;
    // Start is called before the first frame update
    void Start()
    {
        audSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (!audSrc.isPlaying)
            {
                audSrc.clip = loop;
                audSrc.loop = true;
            }

        }
    }
}
