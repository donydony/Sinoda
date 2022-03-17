using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAmount : MonoBehaviour
{
	void Start() {}
	void Update(){}
    public void PlayGame1()
    {
		GameObject numPlayers = new GameObject();
        Debug.Log("Starting a single player game");
		numPlayers.AddComponent<NumPlayers>();
		numPlayers.name = "GlobalPlayerNumber";
		numPlayers.GetComponent<NumPlayers>().numPlayers =1;
        SceneManager.LoadScene("Gamescene");
    }

    public void MainMenu()
    {
        Debug.Log("Back to main menu");
        SceneManager.LoadScene("MainMenu");
    }
	public void PlayGame2()
    {
		GameObject numPlayers = new GameObject();
        Debug.Log("Starting game with 2 players");
		numPlayers.AddComponent<NumPlayers>();
		numPlayers.name = "GlobalPlayerNumber";
		numPlayers.GetComponent<NumPlayers>().numPlayers = 2;
        SceneManager.LoadScene("Gamescene");
    }
    public void PlayGame3()
    {
		GameObject numPlayers = new GameObject();
        Debug.Log("Starting game with 3 players");
		numPlayers.AddComponent<NumPlayers>();
		numPlayers.name = "GlobalPlayerNumber";
		numPlayers.GetComponent<NumPlayers>().numPlayers = 3;
        SceneManager.LoadScene("Gamescene");
    }
	public void PlayGame4()
    {
		GameObject numPlayers = new GameObject();
        Debug.Log("Starting game with 4 players");
		numPlayers.AddComponent<NumPlayers>();
		numPlayers.name = "GlobalPlayerNumber";
		numPlayers.GetComponent<NumPlayers>().numPlayers = 4;
        SceneManager.LoadScene("Gamescene");
    }
}
