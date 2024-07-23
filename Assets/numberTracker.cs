using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public Dictionary<string, int> blockCounts = new Dictionary<string, int>();
    void Start()
    {
        blockCounts.Add("wires", 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
