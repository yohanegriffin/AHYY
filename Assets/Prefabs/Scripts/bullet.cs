using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    
    private void Update()
    {
        transform.position += transform.right * speed;
    }
}
