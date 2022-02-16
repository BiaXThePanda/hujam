using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdLevelEvolve : MonoBehaviour
{

    public GameObject[] button_H;
    public GameObject[] button_B;
    public GameObject[] button_C;
    public Transform left, center, right;
    private string kalan;
    // Start is called before the first frame update
    void Start()
    {
        kalan = CheckEvolves();
        switch (kalan)
        {
            case "Head":
                GameObject inst = Instantiate(button_H[(int)Random.Range(0, 3)], left.position, Quaternion.identity);
                inst.transform.SetParent(gameObject.transform);

                break;
            case "Back":
                GameObject insta = Instantiate(button_B[(int)Random.Range(0, 3)], left.position, Quaternion.identity);
                insta.transform.SetParent(gameObject.transform);


                break;
            case "Combat":
                GameObject instb = Instantiate(button_C[(int)Random.Range(0, 3)], left.position, Quaternion.identity);
                instb.transform.SetParent(gameObject.transform);

                break;



        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string CheckEvolves()
    {
        string name = "";
        for (int i = 0; i < 3; i++)
        {
            int notActive = 0;
            for (int j = 0; j < 3; j++)
            {
                if (GameObject.FindGameObjectWithTag("Player").transform.GetChild(i).GetChild(j).gameObject.activeSelf == false)
                {
                    notActive++;
                    //name = GameObject.FindGameObjectWithTag("Player").transform.GetChild(i).name;
                    Debug.Log(name);
                   
                }
                
            }
            if(notActive == 3)
            {
                name = GameObject.FindGameObjectWithTag("Player").transform.GetChild(i).name;
                break;
            }

        }
        Debug.Log("diskalifiye" + name);
        return name;

    }
}
