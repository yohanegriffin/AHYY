using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void Update()
    {
        transform.position += transform.right * 0.1f;
    }
}
