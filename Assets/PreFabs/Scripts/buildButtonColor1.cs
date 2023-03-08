using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildButtonColor1 : MonoBehaviour
{
    public moneyManager money;

   

    // Update is called once per frame
    void Update()
    {
        if(money.getCurrentMoney() >= 250)
        {
            Image img = gameObject.GetComponent<Image>();
            img.color = new Color32(255, 255, 0, 255);
        }
        else
        {
            Image img = gameObject.GetComponent<Image>();
            img.color = new Color32(115,115,115, 180);
        } 
    }
}
