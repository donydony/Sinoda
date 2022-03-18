using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlight : MonoBehaviour
{
    public Color intial;
    public Color newcolor;
    private bool mouseOver = false;
    public void OnMouseEnter()
    {
        Debug.Log("mouse enter");
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color", newcolor);
    }

    public void OnMouseExit()
    {
        Debug.Log("mouse exit");
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color", intial);
    }
}
