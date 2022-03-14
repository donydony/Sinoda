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
        GameObject exampleDice = Resources.Load("D4") as GameObject;
        Debug.Log("initialized");
        gameBoard = GameObject.Find("Base Game Board");
        gameBoard.GetComponent<Board>().Board_start();
        for (int index = 0; index < 12; index += 1)
        {
            dices[index] = Instantiate(exampleDice);
            dices[index].GetComponent<DiceNew>().updateID(index);
            //dices[index].GetComponent<Rigidbody>().useGravity = false;
        }
        for (int index = 0; index < 54; index += 1)
        {
            int index2 = index + 1;
            string slotname = "Slot" + (index2);
            slots[index] = GameObject.Find(slotname);
        }
        DestroyObject(exampleDice);
        Slots[] got_data = gameBoard.GetComponent<Board>().returnSlots();
        for (int i = 1; i <= got_data.Length; i += 1) //set initial location
        {
            int index = i - 1;
            if (got_data[index].havePiece == true)
            {
                Debug.Log("Problem SET! piece ID" + got_data[index].piece.id);
                dices[got_data[index].piece.id].transform.position = slots[got_data[index].id].transform.position;
                Debug.Log("Updated to" + slots[got_data[index].id].transform.position.x + " " + slots[got_data[index].id].transform.position.y + " " + slots[got_data[index].id].transform.position.z + " ");
            }
        }
        Debug.Log("initialized complete");
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
