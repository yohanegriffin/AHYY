using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoETower : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;
    public float expRadius;
    public float expDamage;
    private List<Collider2D> colliders;

    protected override void shoot()
    {
        
        Enemy enemyScript = currentTarget.GetComponent<Enemy>();
        checkDmgArea(enemyScript);

        GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);
    }

    private void checkDmgArea(Enemy en)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(en.transform.position, expRadius);
        foreach (Collider2D c in colliders)
        {
            if(c.GetComponent<Enemy>())
            {
                Enemy enemyScript = c.GetComponent<Enemy>();

                 enemyScript.takeDamage(expDamage);
            }
            
        }
        en.takeDamage(expDamage);
    }
}
