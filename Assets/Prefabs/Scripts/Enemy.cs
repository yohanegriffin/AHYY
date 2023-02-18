using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Enemy : MonoBehaviour 
{
    [SerializeField] public float enemyHealth; 
    [SerializeField] public float movementSpeed; 
    public playerHealth hp;
    public moneyManager money;
    private bool isSlowed;

    [SerializeField] public int killReward; //The amount of money received when killed
    [SerializeField] public int damage;// Health subtracted when enemy reaches the end 

    public GameObject targetTile; 

    public void Awake()
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

    public void slowEnemy()
     {
        
        StartCoroutine("slowEffect");
        
     }

     private IEnumerator slowEffect()
     {
        if(isSlowed == false)
        {
        isSlowed = true;
        float slow = movementSpeed * 0.25f;
        float origSpeed = movementSpeed;
        movementSpeed = movementSpeed - slow;
        yield return new WaitForSeconds(3f);
        movementSpeed = origSpeed;
        isSlowed = false;
        }
        else{

        }
      
     }
    public void die()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
        money.addMoney(killReward);
    }

    public void reachedEndofLevel()
    {
        Enemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
     
        hp.damagePlayer(damage);
    }

    protected void moveEnemy() {
         gameObject.transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, movementSpeed * Time.deltaTime);
       
    }

    protected void checkPosition() {
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