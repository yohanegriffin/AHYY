using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ChangeScene(string sceneName){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
