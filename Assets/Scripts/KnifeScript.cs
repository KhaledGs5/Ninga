using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{

    Rigidbody2D KnifeRb;
    PolygonCollider2D KnifeColl;
     
    private Vector3 mousePosition;
    public float moveSpeed = 0.2f;


    void Start()
    {
        KnifeRb = gameObject.GetComponent<Rigidbody2D>();
        KnifeColl = gameObject.GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    
    }
}
