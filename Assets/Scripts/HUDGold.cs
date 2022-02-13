using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDGold : MonoBehaviour
{
    public Text goldText;


    public void ChangeGoldTo(int amount)
    {
        goldText.text = amount.ToString();

    }
}
