using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    public Image healthBarBar;
    public GameObject enemy;
    private float origHp;

    public void Start()
    {
        origHp = enemy.GetComponent<Enemy>().enemyHealth;
    }
    public void Update()
    {
        healthBarBar.fillAmount = enemy.GetComponent<Enemy>().enemyHealth / origHp;
    }
}
