using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxGenerater : MonoBehaviour
{
    [SerializeField] private GameObject Prefab;
    private List<GameObject> instantiatedHitBox = new List<GameObject>();

    public GameObject show()
    {
            GameObject Hitb = Instantiate(Prefab);
            instantiatedHitBox.Add(Hitb);
            return Hitb;
    }

    public void close()
    {
        for (int i = 0; i < instantiatedHitBox.Count; i++)
        {
            Destroy(instantiatedHitBox[i]);
        }
        //instantiatedHitBox = new List<GameObject>();
    }

}
