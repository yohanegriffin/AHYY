using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    private int currentPlayerMoney;
    public int starterMoney;

    public void Start()
    {
        currentPlayerMoney = starterMoney;
    }

    public int getCurrentMoney()
    {
        return currentPlayerMoney;
    }

    public void addMoney(int amount)
    {
        currentPlayerMoney += amount;

    }

    public void removeMoney(int amount)
    {
        currentPlayerMoney -= amount;
        Debug.Log("Removed" + amount + " from player's money, the player now has" + currentPlayerMoney);
    }

}
