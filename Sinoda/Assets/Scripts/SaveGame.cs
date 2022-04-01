using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameObject[] pieces;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Game was Saved");
            pieces = GameObject.FindGameObjectsWithTag("TileHighlight");
            Debug.Log("Save file contains this object at the first location "+pieces[0]+ " And the array save file has "+pieces.Length+" objects stored inside it");
        }
    }
}
