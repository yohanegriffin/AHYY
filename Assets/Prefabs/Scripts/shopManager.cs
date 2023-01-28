using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public moneyManager moneyManager;

    public GameObject basicTowerPrefab;
    
    public int basicTowerCost;

    public int getTowerCost(GameObject towerPrefab)
    {
        int cost = 0;

        if(towerPrefab == basicTowerPrefab)
        {
            cost = basicTowerCost;
        }

        return cost;
    }

    public bool canBuyTower(GameObject towerPrefab)
    {
        int cost = getTowerCost(towerPrefab);

        bool canBuy = false;

        if(moneyManager.getCurrentMoney() >= cost)
        {
            canBuy = true;
        }
        return canBuy;
    }


}
