using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeController : MonoBehaviour
{
private static float multiplier = 1.15f;
public moneyManager mon;

    void Start()
    {
   
    }

    
    
    public void Upgrade(){
        barrelTargeting[] gameobj = FindObjectsOfType<barrelTargeting>();
        List<GameObject> lists = new List<GameObject>();

        foreach(barrelTargeting x in gameobj)
        {
            lists.Add(x.gameObject);
        }

        foreach(GameObject j in lists)
        {
            if(j.GetComponent<basicTower>() != null){
                j.GetComponent<basicTower>().damage = j.GetComponent<basicTower>().damage * multiplier;
            }

        }
        mon.removeMoney(250);
    } 
}
