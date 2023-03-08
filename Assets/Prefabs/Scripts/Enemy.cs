using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
    [SerializeField] public float enemyHealth; 
    [SerializeField] public float movementSpeed; 
    public playerHealth hp;
    public moneyManager money;
    public killController kill;



    [SerializeField] public int killReward; //The amount of money received when killed
    [SerializeField] public int damage;// Health subtracted when enemy reaches the end 

    private GameObject targetTile;
    private bool isSlowed;

    protected virtual void Awake()
    {
        Enemies.enemies.Add(gameObject);
    }

    protected virtual void Start() {
    initializeEnemy();
   
    }

    public void initializeEnemy() {
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

        public void slowEnemy()
     {
        
        StartCoroutine("slowEffect");
        
     }

     private IEnumerator slowEffect()
     {
        if(isSlowed == false)
        {
        isSlowed = true;
        float slow = movementSpeed * 0.40f;
        float origSpeed = movementSpeed;
        movementSpeed = movementSpeed - slow;
        yield return new WaitForSeconds(6f);
        movementSpeed = origSpeed;
        isSlowed = false;
        }
        else{

        }
      
     }

    private void die()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
        money.addMoney(killReward);
        kill.addKill();

    }

    private void reachedEndofLevel()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
        hp.damagePlayer(damage);
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
    
    protected virtual void Update() {
    checkPosition();
    if(this){
    moveEnemy();

    }

    
    }
}