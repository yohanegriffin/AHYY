using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private float enemyHealth; 
    [SerializeField] private float movementSpeed; 
    public playerHealth playerHealth;
    public moneyManager moneyManager;
    public HealthBarBehavior HealthBar;


    [SerializeField] private int killReward; //The amount of money received when killed
    [SerializeField] private int damage;// Health subtracted when enemy reaches the end 

    private GameObject targetTile;

    public void Awake()
    {
        Enemies.enemies.Add(gameObject);
    }

    private void Start() {
    initializeEnemy();
      
    }

    private void initializeEnemy() {
       targetTile = mapGenerator.startTile; 
    }

    public void takeDamage(float amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            
            die();
        }
    }

    /*private void addKillReward(int amount)
    {
        moneyManager.removeMoney(amount);
    }
    */
    private void die()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
        moneyManager.addMoney(killReward);
    }

    private void reachedEndofLevel()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
        playerHealth.damagePlayer(damage);
    }

    private void moveEnemy() {
         gameObject.transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
       
    }

    private void checkPosition() {
        if(targetTile != null && targetTile != mapGenerator.endTile) 
        {
            float distance = (transform.position - targetTile.transform.position).magnitude;

            if(distance < 0.001f)
            {
                int currentIndex = mapGenerator.pathTiles.IndexOf(targetTile);

                targetTile = mapGenerator.pathTiles[currentIndex + 1];
            }
        }
        if(targetTile == mapGenerator.endTile)
        {
            reachedEndofLevel();
        }
    }
    
    private void Update() {
    checkPosition();
    if(this){
    moveEnemy();

    }

    
    }
}