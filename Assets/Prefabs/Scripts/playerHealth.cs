using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private float currentPlayerHealth;

    public float startingHealth;

    public void Start()
    {
        resetPlayerHealth();
    }

    public void damagePlayer(float amount)
    {
        currentPlayerHealth -= amount;
        Debug.Log("Did " + amount + " damage, player now has " + getCurrentPlayerHealth() + " health");

    }

    public void resetPlayerHealth()
    {
        currentPlayerHealth = startingHealth;
    }

    public float getCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }
}
