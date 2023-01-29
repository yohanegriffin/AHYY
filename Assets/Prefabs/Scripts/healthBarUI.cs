using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarUI : MonoBehaviour
{
    public playerHealth playerHealth;
    public Image healthBarBar;

    public void Update()
    {
        healthBarBar.fillAmount = playerHealth.getCurrentPlayerHealth() / playerHealth.startingHealth;
    }
}
