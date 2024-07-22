using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject selected;
    public float gridSize = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Place(selected);
        }
    }

    public void SelectBuilding(GameObject sel)
    {
        selected = sel;
    }

    void Place(GameObject s)
    {
        if (s == null)
            return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Snap to grid
        float gridX = Mathf.RoundToInt(mousePos.x / gridSize) * gridSize;
        float gridY = Mathf.RoundToInt(mousePos.y / gridSize) * gridSize;
        Vector2 gridPosition = new Vector2(gridX, gridY);

 
        Instantiate(s, gridPosition, Quaternion.identity);
    }
}
