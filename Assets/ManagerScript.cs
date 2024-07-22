using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject selected;
    public float gridSize=1f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            place(selected);
        }
    }
    void selectBuilding(GameObject sel)
    {
        selected = sel;
    }
    void place(GameObject s)
    {
        Instantiate(s);
    }

}
