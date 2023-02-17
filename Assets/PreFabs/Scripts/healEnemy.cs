using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healEnemy : Enemy
{
    public bool isHealing;
    private float origHealth;

   public void heal()
   {
    origHealth = enemyHealth;
    StartCoroutine("healing");
   }

    private IEnumerator healing()
    {
        if(isHealing == false)
        {
            isHealing = true;
            while(enemyHealth < origHealth)
            {
                if(enemyHealth + 3f > origHealth)
                {
                    enemyHealth = origHealth;
                }
                enemyHealth += 3f;
                yield return new WaitForSeconds(2f);
            }
            
        isHealing = false;
        }
        else{

        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isHealing == false)
        {
            heal();
        }
    }
}
