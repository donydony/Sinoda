using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int slot;
    public Board board;
    public void SetData(Vector3 coords,int slo, int t, Board b)
    {
        coords.y = (float)2;
        transform.position = coords;
        this.slot = slo;
        this.board = b;
        if (t == 1)
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                (transform.eulerAngles.y + 180) % 360,
                transform.eulerAngles.z
            );
        }
    }



}
