using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InnerDriveStudios.DiceCreator
{
    public class DiceNew : MonoBehaviour
    {
        // Start is called before the first frame update
        private int ID;
        private Die _die;
        void Start()
        {
            _die = GetComponent<Die>();
        }
        void Update()
        {
            // GameObject obj = GameObject.Find("D4 0");
            // Debug.Log(obj.GetComponent<MouseClickDieRoller>().face);
            
        }
        public void updateID(int ID)
        {
            this.ID = ID;
        }

        public int getId()
        {
            return ID;
        }
    }
}

