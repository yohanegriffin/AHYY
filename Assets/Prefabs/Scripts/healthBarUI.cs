using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarUI : MonoBehaviour
{
    public playerHealth playerhealth;
    public Image healthBarBar;

    public void Update()
    {
        healthBarBar.fillAmount = playerhealth.getCurrentPlayerHealth() / playerhealth.startingHealth;
    }
}
