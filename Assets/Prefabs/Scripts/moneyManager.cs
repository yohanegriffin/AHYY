using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyManager : MonoBehaviour
{
    private int currentPlayerMoney;
    private int starterMoney;

    public void Start()
    {
        starterMoney = 50;
        this.currentPlayerMoney = starterMoney;
        Debug.Log("Current Money " + getCurrentMoney());
    }

    public int getCurrentMoney()
    {
        return this.currentPlayerMoney;
    }

    public void addMoney(int amount)
    {
        this.currentPlayerMoney += amount;
        Debug.Log("Added " + amount + " to player's money, the player now has " + this.currentPlayerMoney);
    }

    public void removeMoney(int amount)
    {
        this.currentPlayerMoney -= amount;
        Debug.Log("Removed" + amount + " from player's money, the player now has " + this.currentPlayerMoney);
    }

}
