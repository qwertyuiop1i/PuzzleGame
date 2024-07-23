using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireCode : MonoBehaviour
{
    public float tileSize = 1f;
    private Sprite[] costumes;
    public GameObject GetNeighboringTile(GameObject currentTile, int direction)
    {
        Vector3 currentPosition = currentTile.transform.position;
        Vector3 targetPosition = currentPosition;

        switch (direction)
        {
            case 1: // Right
                targetPosition += Vector3.right * tileSize;
                break;
            case 2: // Up
                targetPosition += Vector3.up * tileSize;
                break;
            case 3: // Left
                targetPosition += Vector3.left * tileSize;
                break;
            case 4: // Down
                targetPosition += Vector3.down * tileSize;
                break;
            default:
                Debug.LogError("Invalid direction provided: " + direction);
                return null;
        }

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
