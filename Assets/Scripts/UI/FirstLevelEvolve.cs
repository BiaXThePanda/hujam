using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevelEvolve : MonoBehaviour
{

    public GameObject[] button_H;
    public GameObject[] button_B;
    public GameObject[] button_C;
    public Transform left, center, right;
    void Start()
    {
        GameObject inst = Instantiate(button_H[(int)Random.Range(0,3)],center.position,Quaternion.identity);
        inst.transform.parent = gameObject.transform;
        inst = Instantiate(button_B[(int)Random.Range(0, 3)], left.position, Quaternion.identity);
        inst.transform.parent = gameObject.transform;
        inst = Instantiate(button_C[(int)Random.Range(0, 3)], right.position, Quaternion.identity);
        inst.transform.parent = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
