using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceGenerater : MonoBehaviour
{
    //[SerializeField] private GameObject prefab;
    [SerializeField] private GameObject[] prefabs;

    public GameObject CreatePiece(int team)
    {

        GameObject newPiece = Instantiate(prefabs[team]);
        return newPiece;
    }
}
