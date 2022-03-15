using System.Collections;
using System.Collections.Generic;
using InnerDriveStudios.DiceCreator;
using UnityEngine;

public class cameraInteract : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] dices = new GameObject[12];
    private GameObject[] slots = new GameObject[54];
    private GameObject gameBoard;
    void Start()
    {
        Debug.Log("initialized");
        gameBoard = GameObject.Find("Base Game Board");
        gameBoard.GetComponent<Board>().Board_start();
        // slot init
        for (int index = 0; index < 54; index += 1)
        {
            slots[index] = GameObject.Find("Slot" + index);
        }
        Slots[] got_data = gameBoard.GetComponent<Board>().returnSlots();
        Debug.Log("get length " + got_data.Length);
        
        for (int index = 0; index < 12; index ++)
        {
            dices[index] = (GameObject)Resources.Load("D4");
            Vector3 v = Vector3.zero;
            for (int j = 0; j < 24; j ++)
            {
                if (got_data[j].havePiece && got_data[j].piece.id == index)
                {
                    v = slots[j].transform.position;
                }
            }

            v = new Vector3(v.x, v.y+1f, v.z);
            // dices[index].transform.localScale = new Vector3(3, 3, 3);
            Instantiate(dices[index], v, Quaternion.identity);
            dices[index].GetComponent<DiceNew>().updateID(index);
            dices[index].name = "D4 " + index;
            
            // dices[index].GetComponent<Rigidbody>().useGravity = false;
        }
        for (int i = 1; i <= got_data.Length; i += 1) //set initial location
        {
            Debug.Log("logged");
            int index = i - 1;
            // if (got_data[index].havePiece)
            // {
            //     dices[got_data[index].piece.id].transform.position = new Vector3(slots[got_data[index].piece.id - 1].transform.position.x, slots[got_data[index].piece.id - 1].transform.position.y, slots[got_data[index].piece.id - 1].transform.position.z);
            //     Debug.Log(slots[got_data[index].piece.id - 1].transform.position.x+ " " + slots[got_data[index].piece.id - 1].transform.position.y + " " + slots[got_data[index].piece.id - 1].transform.position.z);
            // }
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
