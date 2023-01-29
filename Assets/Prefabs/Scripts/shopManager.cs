using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public moneyManager moneyManager;

    public GameObject basicTowerPrefab;
    public GameObject sniperTowerPrefab;
    public GameObject fastTowerPrefab;
    
    public int basicTowerCost;
    public int sniperTowerCost;
    public int fastTowerCost;

    public int getTowerCost(GameObject towerPrefab)
    {
        int cost = 0;

        if(towerPrefab == basicTowerPrefab)
        {
            cost = basicTowerCost;
        }
        else if(towerPrefab == sniperTowerPrefab)
        {
            cost = sniperTowerCost;
        }
        else if(towerPrefab == fastTowerPrefab)
        {
            cost = fastTowerCost;
        }

        return cost;
    }

    public void buyTower(GameObject towerPrefab)
    {
        moneyManager.removeMoney(getTowerCost(towerPrefab));
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
