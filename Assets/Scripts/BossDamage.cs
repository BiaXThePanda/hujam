using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(float amount)
    {
        if (this.GetComponent<Boss>() != null)
        {
            GetComponent<Boss>().GetDamage(amount);
        }
        else
        {
            GetComponent<BossSecond>().GetDamage(amount);

        }
    }
}
