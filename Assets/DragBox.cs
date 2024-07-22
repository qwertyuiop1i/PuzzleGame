using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBox : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

      
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        transform.rotation = rotation;
            
       
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

    }
    void transmute()
    {
        Debug.Log("add");
    }
}
