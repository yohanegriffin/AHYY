using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    public GameObject Script;

    // Start is called before the first frame update
    public void Start()
    {
        Script.SetActive(false);
    }

    public void OnMouseOver()
    {
        Script.SetActive(true);
    }

    // Update is called once per frame
    public void OnMouseExit()
    {
        Script.SetActive(false);
    }
}
