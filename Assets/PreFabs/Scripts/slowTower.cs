using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowTower : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;

    protected override void shoot()
    {
        Enemy enemyScript = currentTarget.GetComponent<Enemy>();
        enemyScript.slowEnemy();

        GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);
    }
}
