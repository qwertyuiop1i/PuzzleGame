using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireCode : MonoBehaviour
{
    public float tileSize = 1f;

    public GameObject GetTileToTheRight(GameObject currentTile)
    {
        Vector3 currentPosition = currentTile.transform.position;
        Vector3 targetPosition = currentPosition + Vector3.right * tileSize;
        Collider2D targetCollider = Physics2D.OverlapBox(targetPosition, Vector2.one * tileSize * 0.5f, 0f);

        if (targetCollider != null)
        {
            return targetCollider.gameObject;
        }
        else
        {
            return null;
        }
    }

    public GameObject GetTileToTheLeft(GameObject currentTile)
    {
        Vector3 currentPosition = currentTile.transform.position;
        Vector3 targetPosition = currentPosition + Vector3.left * tileSize;
        Collider2D targetCollider = Physics2D.OverlapBox(targetPosition, Vector2.one * tileSize * 0.5f, 0f);

        if (targetCollider != null)
        {
            return targetCollider.gameObject;
        }
        else
        {
            return null; 
        }
    }
  
   
}
