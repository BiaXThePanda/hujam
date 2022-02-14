using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolveUI : MonoBehaviour
{
    public GameObject[] button_H;
    public GameObject[] button_B;
    public GameObject[] button_C;
    public Transform left, center, right;
    
    public bool hasHead, hasBack, hasCombat;
    private void Start()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0;i<3;i++)
        {
            if (player.transform.GetChild(0).GetChild(i).gameObject.activeSelf)
            {
                hasHead = true;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (player.transform.GetChild(1).GetChild(i).gameObject.activeSelf)
            {
                hasBack = true;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (player.transform.GetChild(2).GetChild(i).gameObject.activeSelf)
            {
                hasCombat = true;
            }
        }

    }
    private void Update()
    {
        
    }

}
