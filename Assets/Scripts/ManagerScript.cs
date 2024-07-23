using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject selected;

    public float gridSize = 1 / (Mathf.Sqrt(2));
    //public bool rotatable;
    private List<GameObject> placedObjects = new List<GameObject>();

    public List<List<GameObject>> grid;

    public GameObject gr;

    public GameObject initialCirc;

    private int gridIndexX;
    private int gridIndexY;
    public void Start()
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
        gridIndexX = Mathf.RoundToInt((initialCirc.transform.position.x + gridSize / 2 + 7.778f) / gridSize);
        gridIndexY = Mathf.RoundToInt((initialCirc.transform.position.y + gridSize / 2 + 2.121f) / gridSize);


        if (gridIndexX >= 0 && gridIndexX < grid.Count && gridIndexY >= 0 && gridIndexY < grid[0].Count)
        {
            grid[gridIndexX][gridIndexY] = initialCirc;
        }

    }
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
        temp.transform.parent = gr.transform;
        placedObjects.Add(temp);


        gridIndexX = Mathf.RoundToInt((gridPosition.x + gridSize / 2+7.778f) / gridSize);
        gridIndexY = Mathf.RoundToInt((gridPosition.y + gridSize / 2+2.121f) / gridSize);

     
        if (gridIndexX >= 0 && gridIndexX < grid.Count && gridIndexY >= 0 && gridIndexY < grid[0].Count)
        {
            grid[gridIndexX][gridIndexY] = temp;
        }



    }

    void UndoPlacement()
    {

        if (placedObjects.Count > 0)
        {
            GameObject lastPlaced = placedObjects[placedObjects.Count - 1];
            placedObjects.RemoveAt(placedObjects.Count - 1);
            Destroy(lastPlaced);
        }
        
        if (gridIndexX >= 0 && gridIndexX < grid.Count && gridIndexY >= 0 && gridIndexY < grid[0].Count)
        {
            grid[gridIndexX][gridIndexY] = null;
        }
    }

    public void play()
    {

    }
}
