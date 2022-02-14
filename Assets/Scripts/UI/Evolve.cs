using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);
    }
    public void ActivateHelmet2()
    {
        checkEvolves.Heads[1].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
    public void ActivateHelmet3()
    {
        checkEvolves.Heads[2].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
    public void ActivateBack1()
    {
        checkEvolves.Backs[0].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
    public void ActivateBack2()
    {
        checkEvolves.Backs[1].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
    public void ActivateBack3()
    {
        checkEvolves.Backs[2].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
    public void ActivateCombat1()
    {
        checkEvolves.Combats[0].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
    public void ActivateCombat2()
    {
        checkEvolves.Combats[1].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
    public void ActivateCombat3()
    {
        checkEvolves.Combats[2].SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject.transform.parent);

    }
}
