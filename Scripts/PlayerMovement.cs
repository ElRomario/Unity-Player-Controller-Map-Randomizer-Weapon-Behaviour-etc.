using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    internal Rigidbody2D rb;
    public Vector2 moveDir;
    public Vector2 prevDir;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
        prevDir = moveDir;
    }

    
    void Update()
    {
        MovementInputManager();
    }

    
    void MovementInputManager()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY);    
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
