using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public GameObject selected;

    public bool isPlaying = false;

    public float gridSize = 1 / (Mathf.Sqrt(2));
    //public bool rotatable;
    private List<GameObject> placedObjects = new List<GameObject>();

    public List<List<GameObject>>? grid;

    public GameObject gr;

    public GameObject initialCirc;

    private int gridIndexX;
    private int gridIndexY;

    public GameObject lit;

    private HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

    public bool HasWirePathToLight(GameObject ic)
    {
        if (ic == null || lit == null || grid == null || grid.Count == 0)
        {
            return false;
        }

        gridIndexX = Mathf.RoundToInt((ic.transform.position.x + gridSize / 2 + 7.778f) / gridSize);
        gridIndexY = Mathf.RoundToInt((ic.transform.position.y + gridSize / 2 + 2.121f) / gridSize);


        bool[,] visited = new bool[grid.Count, grid[0].Count];

        return DFS(gridIndexX, gridIndexY, visited);
    }

    private bool DFS(int x, int y, bool[,] visited)
    {
        // Base cases
        if (grid[x][y] == null)
        {
            return false;
        }
        if (x < 0 || x >= grid.Count || y < 0 || y >= grid[0].Count)
        {
            Debug.Log("Failed at b/c COUNTING ERROR " + x + " " + y);
            return false;
        }
        if (visited[x, y])
        {
            Debug.Log("Failed at b/c visited ERROR " + x + " " + y);
            return false;
        }
        if (grid[x][y] == lit)
            return true;

        visited[x, y] = true;
        //Debug.Log("analy1");
        // Check neighbors (up, down, left, right)
        if (grid[x][y] != null)
        {
            Debug.Log(grid[x][y].name + " at " + x + " " + y);
        }
        if (grid[x][y].tag == "Wire"||grid[x][y].name=="circut")

        {
            Debug.Log("analy2");
            return DFS(x + 1, y, visited) ||
                   DFS(x - 1, y, visited) ||
                   DFS(x, y + 1, visited) ||
                   DFS(x, y - 1, visited);
        }

        return false;
    }
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
            Debug.Log(gridIndexX + " " + gridIndexY);
        }

        gridIndexX = Mathf.RoundToInt((lit.transform.position.x + gridSize / 2 + 7.778f) / gridSize);
        gridIndexY = Mathf.RoundToInt((lit.transform.position.y + gridSize / 2 + 2.121f) / gridSize);


        if (gridIndexX >= 0 && gridIndexX < grid.Count && gridIndexY >= 0 && gridIndexY < grid[0].Count)
        {
            grid[gridIndexX][gridIndexY] = lit;
            Debug.Log(gridIndexX + " " + gridIndexY);
        }

    }
    void Update()
    {
        if (!isPlaying) {
            if (Input.GetMouseButtonDown(0))
            {
                Place(selected);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                UndoPlacement();
            }
        }
        if (isPlaying)
        {

            gridIndexX = Mathf.RoundToInt((initialCirc.transform.position.x + gridSize / 2 + 7.778f) / gridSize);
            gridIndexY = Mathf.RoundToInt((initialCirc.transform.position.y + gridSize / 2 + 2.121f) / gridSize);

            if (HasWirePathToLight(initialCirc))
            {
                Debug.Log("true");
            }


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
        Debug.Log(gridIndexX + " " + gridIndexY);



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
