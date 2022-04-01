using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTile : MonoBehaviour
{
    public Color initial;
    public Color changeColor;
    public Material objectMaterial;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit rayhit;

        if (Physics.Raycast(ray, out rayhit))
        {
            if (rayhit.collider.gameObject.tag == "TileHighlight")
            {
                Debug.Log("hit object");
                objectMaterial.SetColor("_Color", changeColor);
            }
        }
    }
}
