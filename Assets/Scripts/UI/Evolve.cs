using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour
{

    CheckEvolves checkEvolves;




    private void Start()
    {
        checkEvolves = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckEvolves>();
    }


    public void ActivateHelmet1()
    {
        checkEvolves.Heads[0].SetActive(true);
        Destroy(gameObject);
    }
    public void ActivateHelmet2()
    {
        checkEvolves.Heads[1].SetActive(true);
        Destroy(gameObject);

    }
    public void ActivateHelmet3()
    {
        checkEvolves.Heads[2].SetActive(true);
        Destroy(gameObject);

    }
    public void ActivateBack1()
    {
        checkEvolves.Backs[0].SetActive(true);
        Destroy(gameObject);

    }
    public void ActivateBack2()
    {
        checkEvolves.Backs[1].SetActive(true);
        Destroy(gameObject);

    }
    public void ActivateBack3()
    {
        checkEvolves.Backs[2].SetActive(true);
        Destroy(gameObject);

    }
    public void ActivateCombat1()
    {
        checkEvolves.Combats[0].SetActive(true);
        Destroy(gameObject);

    }
    public void ActivateCombat2()
    {
        checkEvolves.Combats[1].SetActive(true);
        Destroy(gameObject);

    }
    public void ActivateCombat3()
    {
        checkEvolves.Combats[2].SetActive(true);
        Destroy(gameObject);

    }
}
