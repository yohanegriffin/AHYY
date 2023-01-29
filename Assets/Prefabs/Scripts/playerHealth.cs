using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private int currentPlayerHealth;

    public int startingHealth;

    public void Start()
    {
        resetPlayerHealth();
    }

    public void damagePlayer(int amount)
    {
        currentPlayerHealth -= amount;
        Debug.Log("Did " + amount + " damage, player now has " + getCurrentPlayerHealth() + " health");

    }

    public void resetPlayerHealth()
    {
        currentPlayerHealth = startingHealth;
    }

    public int getCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }
}
