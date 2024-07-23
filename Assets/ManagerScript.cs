using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject selected;
    public GameObject grid;
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

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float gridX = Mathf.RoundToInt(mousePos.x / gridSize) * gridSize;
        float gridY = Mathf.RoundToInt(mousePos.y / gridSize) * gridSize;
        Vector2 gridPosition = new Vector2(gridX, gridY);

        Collider2D overlap = Physics2D.OverlapBox(gridPosition, s.GetComponent<Collider2D>().bounds.size, 0f);
        if (overlap != null)
        {
           
            Debug.Log("Collision detected!");
            return;
        }

        GameObject temp = Instantiate(s, gridPosition, Quaternion.identity);
        temp.transform.parent = grid.transform;
    }
}
