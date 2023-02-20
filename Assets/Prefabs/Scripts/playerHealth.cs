using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(currentPlayerHealth <= 0)
        {
            endGame();
        }

    }

    public void resetPlayerHealth()
    {
        currentPlayerHealth = startingHealth;
    }

    public float getCurrentPlayerHealth()
    {
        return currentPlayerHealth;
    }

    public void endGame()
    {
        SceneManager.LoadScene("gameOverScene");
    }

}
