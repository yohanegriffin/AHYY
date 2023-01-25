using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelTargeting : MonoBehaviour
{
    public Transform pivot;
    public Transform barrel;

    public Tower tower;

    private void Update()
    {
        if(tower != null)
        {
            if(tower.currentTarget != null)
            {
            Vector2 relative = tower.currentTarget.Transform.position - pivot.position;

            float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;


            }
        }
    }
}
