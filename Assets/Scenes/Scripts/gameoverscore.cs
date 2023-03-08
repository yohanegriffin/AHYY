using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameoverscore : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject kill;
    
    // Start is called before the first frame update
    void Start()
    {
        kill = GameObject.Find("killController");
        text.text = "Total Kills: " +  PlayerPrefs.GetInt("kills");
    }

   
}
