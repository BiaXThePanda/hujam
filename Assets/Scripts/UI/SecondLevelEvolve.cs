using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelEvolve : MonoBehaviour
{
    public GameObject[] button_H;
    public GameObject[] button_B;
    public GameObject[] button_C;
    public Transform left, center, right;
    private string diskalifiye;
    // Start is called before the first frame update
    void Start()
    {
        diskalifiye = CheckEvolves();
        switch (diskalifiye)
        {
            case "Head":
                GameObject inst = Instantiate(button_B[(int)Random.Range(0, 3)], left.position,Quaternion.identity);
                inst.transform.parent = transform.parent;
                inst = Instantiate(button_C[(int)Random.Range(0, 3)], right.position, Quaternion.identity);
                inst.transform.parent = transform.parent;
                break;
            case "Back":
                GameObject insta = Instantiate(button_H[(int)Random.Range(0, 3)], left.position, Quaternion.identity);
                insta.transform.parent = transform.parent;
                insta = Instantiate(button_C[(int)Random.Range(0, 3)], right.position, Quaternion.identity);
                insta.transform.parent = transform.parent;
                break;
            case "Combat":
                GameObject instb =  Instantiate(button_B[(int)Random.Range(0, 3)], left.position, Quaternion.identity);
                instb.transform.parent = transform.parent;
                instb = Instantiate(button_H[(int)Random.Range(0, 3)], right.position, Quaternion.identity);
                instb.transform.parent = transform.parent;
                break;



        }

      //  GameObject inst = Instantiate();
    }

    public string CheckEvolves()
    {
        string name = "";
        for(int i = 0;i< 3; i++)
        {
            for(int j = 0; j<3;j++)
            if (GameObject.FindGameObjectWithTag("Player").transform.GetChild(i).GetChild(j).gameObject.activeSelf) {


                    name = GameObject.FindGameObjectWithTag("Player").transform.GetChild(i).name;
                    break;
            }
                
        }
        return name;
        
    }
}
