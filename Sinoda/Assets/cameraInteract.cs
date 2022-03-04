using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] dices = new GameObject[12];
    private GameObject[] slots = new GameObject[54];
    private GameObject gameBoard;
    void Start()
    {
        gameBoard = GameObject.Find("Base Game Board");
        for (int index = 0; index < 12; index += 1)
        {
            dices[index] = (GameObject)Resources.Load("D4");
            Instantiate(dices[index]);
            dices[index].GetComponent<DiceNew>().updateID(index);
            //dices[index].GetComponent<Rigidbody>().useGravity = false;
        }
        for (int index = 0; index < 54; index += 1)
        {
            slots[index] = GameObject.Find("Slot" + index);
        }
        for (int index = 1; index<= 54;index += 1) //set initial location
        {
            int returnval = gameBoard.GetComponent<Board>().getSlotPieceOwner(index);
            if (returnval != -1)
            {
                 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider.gameObject.tag == "D4")
                    Debug.Log("Hit dice");
        }

    }
}
