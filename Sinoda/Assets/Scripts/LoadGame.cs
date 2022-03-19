using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadGame : MonoBehaviour
{
    private GameObject[] obj;
    private static string path = "Assets/savefile.txt";
    private StreamReader reader = new StreamReader(path);
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject x in obj)
        {
            //commented out this line for now as prefab is not being detected due to editor bug
          //  Instantiate(piecePrefab, x.transform.position, x.transform.rotation);

          Debug.Log("Loading Game Object");
        }
    }
}
