using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildButtonColor : MonoBehaviour
{
    public shopManager shop;
    public moneyManager money;
    public GameObject towerPre;
   

    // Update is called once per frame
    void Update()
    {
        if(money.getCurrentMoney() >= shop.getTowerCost(towerPre))
        {
            Image img = gameObject.GetComponent<Image>();
            img.color = new Color32(114, 250, 84, 255);
        }
        else
        {
            Image img = gameObject.GetComponent<Image>();
            img.color = new Color32(115,115,115, 180);
        }
    }
}
