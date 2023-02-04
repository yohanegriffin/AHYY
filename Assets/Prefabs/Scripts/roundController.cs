using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roundController : MonoBehaviour
{
    public GameObject basicEnemy;
    public GameObject fastEnemy;
    public GameObject tankEnemy;

    public float timeBetweenWaves;
    public float timeBeforeRoundStarts;
    public float timeVariable;

    public bool isRoundGoing;
    public bool isIntermission;
    public bool isStartOfRound;

    public playerHealth playerHealth;

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
            
            if(round % 2 == 0)
            {
                GameObject newEnemy2 = Instantiate(basicEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
                GameObject newFastEnemy = Instantiate(fastEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
            }

            if(round % 5 == 0)
            {
                GameObject newEnemy3 = Instantiate(basicEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
                GameObject newTankEnemy = Instantiate(tankEnemy, mapGenerator.startTile.transform.position, Quaternion.identity);
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
            if(Enemies.enemies.Count > 3)
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
