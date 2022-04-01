using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMain : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Returning to Menu");
        SceneManager.LoadScene("MainMenu");
    }

}
