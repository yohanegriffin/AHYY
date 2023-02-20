using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MenuScene(){
        SceneManager.LoadScene("Menu");
    }
    public void OptionsMenu(){
        SceneManager.LoadScene("OptionsMenu");
    }
    public void gameScene(){
        SceneManager.LoadScene("gameScene");
    }

public void QuitGame (){
    Debug.Log("QUIT");
    Application.Quit(); 
}
    public void MuteToggle(bool muted){
        if (muted){
            AudioListener.volume = 0;
        }
        else{
            AudioListener.volume = 100;
        }
    }
}
