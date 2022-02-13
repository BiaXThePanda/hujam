using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{


    public int health;

    public GameObject[] healths;

    public void ChangeHealth(int amount)
    {
            if (amount < 0 && health != 0)
            {
                for(int i = 3; i >= 0; i--)
                {
                    if (healths[i].activeSelf)
                    {
                        healths[i].SetActive(false);
                        health--;
                        break;
                    }
                }
            }
            else if(amount>0 && health != 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (!healths[i].activeSelf)
                    {
                        healths[i].SetActive(true);
                        health++;
                        break;
                    }
                }
            } 
    }
}
