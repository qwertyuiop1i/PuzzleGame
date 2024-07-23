using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    public float mass;
    public float gridSize;
    public Rigidbody2D rb;
    public float conductivity;
    public GameObject initialCirc;
    public List<List<GameObject>> grid;
    void Start()
    {
        grid = new List<List<GameObject>>();

        for (int x = 0; x < 10; x++)
        {
            grid.Add(new List<GameObject>());
            for (int y = 0; y < 24; y++)
            {
                
                grid[x].Add(null);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
