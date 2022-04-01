using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Starting Game");
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
	public void twoPlayers()
    {
		SceneManager.LoadScene("TileScene2");
	}

    public void vsAIGame()
    {
        SceneManager.LoadScene("TileScene");
    }

    public void threePlayers()
    {
        SceneManager.LoadScene("TileScene3");
    }

    public void gotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
