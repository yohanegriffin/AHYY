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

    protected override void shoot()
    {
        base.shoot();

        GameObject newBullet = Instantiate(bullet, barrel.position, pivot.rotation);
    }
}
