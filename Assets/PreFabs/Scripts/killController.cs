using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class killController : MonoBehaviour
{

    public TextMeshProUGUI text;
    public static int kills;
    void Start()
    {
        kills = 0;
    }

    public void addKill()
    {
         kills++;
         PlayerPrefs.SetInt("kills", kills);
    }

   
    // Update is called once per frame
    void Update()
    {
        text.text = "Kills: " + kills;
    }
}
