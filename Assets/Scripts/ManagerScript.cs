using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject selected;
    public GameObject grid;
    public float gridSize = 1f;

    private List<GameObject> placedObjects = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Place(selected);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoPlacement();
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
        placedObjects.Add(temp);
    }

    void UndoPlacement()
    {
        if (placedObjects.Count > 0)
        {
            GameObject lastPlaced = placedObjects[placedObjects.Count - 1];
            placedObjects.RemoveAt(placedObjects.Count - 1);
            Destroy(lastPlaced);
        }
    }
}
