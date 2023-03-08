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
    public killController kill;

    public int round;
    public float multi;

    private void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStarts;

        round = 1;
        multi = 1f;
    }
    private void spawnEnemies()
    {
        StartCoroutine("iSpawnEnemies");
    }

    IEnumerator iSpawnEnemies()
    {
        
        if(round <= 5){
            if(round % 2 == 0)
            {
                
                for(int i = 0; i < round - 1; i++){
                createFastEnemy();
                yield return new WaitForSeconds(0.35f);
                }
            }


            for(int i = 0; i < round; i++){
            createBasicEnemy();
            yield return new WaitForSeconds(0.5f);
            }
            
            
            

            if(round % 4 == 0)
            {
                for(int i = 0; i < round; i++){
                createHealEnemy();
                yield return new WaitForSeconds(0.4f);
                }        
            }
           

            if(round % 5 == 0)
            {
                multi = multi + 0.25f;
                for(int i = 0; i < round - 3; i++){
                createTankEnemy();
                yield return new WaitForSeconds(0.75f);
                }        
            
                for(int i = 0; i < round - 1; i++){
                createStrongEnemy();
                yield return new WaitForSeconds(0.35f);
                }        
            }
        }
   
        if(round > 5){

            
            for(int i = 0; i < round + 1; i++){
            createBasicEnemy();
            yield return new WaitForSeconds(0.75f);
            }
            for(int i = 0; i < round + 2; i++){
                createFastEnemy();
                yield return new WaitForSeconds(0.4f);
                }
            for(int i = 0; i < round - 5; i++){
                createTankEnemy();
                yield return new WaitForSeconds(0.75f);
                }    
            for(int i = 0; i < round - 1; i++){
                createHealEnemy();
                yield return new WaitForSeconds(0.75f);
                }  
            for(int i = 0; i < round - 2; i++){
                createStrongEnemy();
                yield return new WaitForSeconds(0.75f);
                }        
        
        }
        yield return new WaitForSeconds(0.1f);
    }
    private void createBasicEnemy()
    {
        
        GameObject newEnemy = Instantiate(basicEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().money = money;
        newEnemy.GetComponent<Enemy>().hp = hp;
        newEnemy.GetComponent<Enemy>().kill = kill;
        newEnemy.GetComponent<Enemy>().enemyHealth = newEnemy.GetComponent<Enemy>().enemyHealth * multi;
    }

    private void createFastEnemy()
    {
 
        GameObject newEnemy = Instantiate(fastEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().money = money;
        newEnemy.GetComponent<Enemy>().hp = hp;
        newEnemy.GetComponent<Enemy>().kill = kill;
        newEnemy.GetComponent<Enemy>().enemyHealth = newEnemy.GetComponent<Enemy>().enemyHealth * multi;
    }

    private void createTankEnemy()
    {
  
        GameObject newEnemy = Instantiate(tankEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().money = money;
        newEnemy.GetComponent<Enemy>().hp = hp;
        newEnemy.GetComponent<Enemy>().kill = kill;
        newEnemy.GetComponent<Enemy>().enemyHealth = newEnemy.GetComponent<Enemy>().enemyHealth * multi;
    }

    private void createHealEnemy()
    {

        GameObject newEnemy = Instantiate(healEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().money = money;
        newEnemy.GetComponent<Enemy>().hp = hp;
        newEnemy.GetComponent<Enemy>().kill = kill;
        newEnemy.GetComponent<Enemy>().enemyHealth = newEnemy.GetComponent<Enemy>().enemyHealth * multi;
    }

    private void createStrongEnemy()
    {
   
        GameObject newEnemy = Instantiate(strongerEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().money = money;
        newEnemy.GetComponent<Enemy>().hp = hp;
        newEnemy.GetComponent<Enemy>().kill = kill;
        newEnemy.GetComponent<Enemy>().enemyHealth = newEnemy.GetComponent<Enemy>().enemyHealth * multi;
    }

    public void Update()
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
