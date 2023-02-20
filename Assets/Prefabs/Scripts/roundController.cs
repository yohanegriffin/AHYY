using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roundController : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject fastEnemy;
    public GameObject tankEnemy;
    public GameObject strongerEnemy;
    public GameObject healEnemy;

    public float timeBetweenWaves;
    public float timeBeforeRoundStarts;
    public float timeVariable;

    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;

    public playerHealth hp;
    public moneyManager money;

    public int round;
    

    private void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStarts;

        round = 1;
  
    }
    private void spawnEnemies()
    {
        StartCoroutine("iSpawnEnemies");
    }

    IEnumerator iSpawnEnemies()
    {
        for(int i = 0; i < round; i++)
        {
                GameObject newEnemy = Instantiate(basicEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
                newEnemy.GetComponent<Enemy>().money = money;
                newEnemy.GetComponent<Enemy>().hp = hp;


            
            
            
            if(round % 2 == 0)
            {
                GameObject newFastEnemy = Instantiate(fastEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
                newFastEnemy.GetComponent<Enemy>().money = money;
                newFastEnemy.GetComponent<Enemy>().hp = hp;

              for(int j = 0; j < round - 1; j++)
               {
                      GameObject newHeal = Instantiate(healEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
                newHeal.GetComponent<healEnemy>().money = money;
                newHeal.GetComponent<healEnemy>().hp = hp;
               }
               
            }

           

            if(round % 5 == 0)
            {
                GameObject newTankEnemy = Instantiate(tankEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
                newTankEnemy.GetComponent<Enemy>().money = money;
                newTankEnemy.GetComponent<Enemy>().hp = hp;

                
                GameObject hardEnemy = Instantiate(strongerEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
                hardEnemy.GetComponent<Enemy>().money = money;
                hardEnemy.GetComponent<Enemy>().hp = hp;
                
            }
            yield return new WaitForSeconds(1f);
        }
        
    }

    private void Update()
    {
        if(isStartOfRound)
        {
            if(Time.time >= timeVariable)
            {
                isStartOfRound = false;
                isRoundGoing = true;

                spawnEnemies();
                return;
            }
        }
        else if(isIntermission)
        {
            if(Time.time >= timeVariable)
            {
                isIntermission = false;
                isRoundGoing = true;

                spawnEnemies();
            }
        }
        else if(isRoundGoing)
        {
            Debug.Log(Enemies.enemies.Count);
            if(Enemies.enemies.Count > 0)
            {

            }
            else
            {
                isIntermission = true;
                isRoundGoing = false;

                timeVariable = Time.time + timeBetweenWaves;
                round++;
            }
        }
    }
}
