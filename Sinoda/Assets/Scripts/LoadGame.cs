using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadGame : MonoBehaviour
{
    private GameObject[] obj;
    private string static path = "Assets/savefile.txt";
    private StreamReader reader = new StreamReader(path);
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject x in obj)
        {
            Instantiate(piecePrefab, x.transform.position, x.transform.rotation);
        }
    }
}
