using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void ToggleFullscreen(bool n)
    {
        Screen.fullScreen = n;
        Debug.Log("Fullscreen: " + n);
    }
    
    public void MainMenu()
    {
        Debug.Log("Settings->Mainmenu");
        SceneManager.LoadScene("Mainmenu");
    }
    
}
