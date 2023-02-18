using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healEnemy : Enemy
{
    public bool isHealing;
    private static float origHealth;

   protected override void Start()
    {
        base.Start();
        origHealth = enemyHealth;
        isHealing = false;
    }

    public void heal()
    {
        StartCoroutine("healing");
    }

    private IEnumerator healing()
    {
        if(isHealing == false)
        {
            isHealing = true;
            while(enemyHealth < origHealth)
            {
                if(enemyHealth + 5f > origHealth)
                {
                    enemyHealth = origHealth;
                }
                else{
                    enemyHealth += 5f;
                }
                
                yield return new WaitForSeconds(5f);
            }
            
            isHealing = false;
        }
        else{

        }
    }

 

    // Update is called once per frame
   protected override void Update()
    {
        base.Update();
        if(enemyHealth < origHealth)
        {
            heal();
        }
    }
}
