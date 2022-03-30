using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Game input system
 * Use tag to identify game object
 * Feel free to add any object that you want 
 * Or if there are other object you want a receiver just create a interface and replace MonoBehavior
 */
public class Receiver : MonoBehaviour
{
    public Board board;
    private void Awake()
    {
        board = GetComponent<Board>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.tag == "Piece")
                {

                    board.HandlePiece(hit.transform.gameObject.GetComponent<Piece>());
                }
                else if (hit.collider.tag == "HitBox")
                {

                    board.HandleHitBox(hit.transform.gameObject.GetComponent<HitBox>());
                }
                else if (hit.collider.tag == "rollup")
                {

                    board.rollup();
                }
                else if (hit.collider.tag == "rolldown")
                {

                    board.rolldown();
                }
            }
        }
    }
}
