using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Player amount selection");
        SceneManager.LoadScene("PlayerAmount");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene("Quit");
    }

    public void OptionsMenu()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("Settings");
    }
}