using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class moneyTextUI : MonoBehaviour
{
    public moneyManager moneyManager;

    public TextMeshProUGUI moneyText;

    public void Update()
    {
        moneyText.text = "$: " + moneyManager.getCurrentMoney();
    }

}
