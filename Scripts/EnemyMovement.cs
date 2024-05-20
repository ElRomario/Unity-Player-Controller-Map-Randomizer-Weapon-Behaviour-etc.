using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    Transform player;
    public float moveSpeed;
    public bool left;
    public bool right;
    public bool up;
    public bool down;

    
    internal Vector2 nintyDegreese = new(0, 10);
    internal Vector2 prevPos;
    internal Vector2 nextPos = new();
    internal Vector2 curPos;
    internal Vector2 direction;
    internal float angle;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        curPos = transform.position;
        DirectionChecker();
        direction = (prevPos - curPos);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log($"Angle of enemy:{angle}");
        prevPos = curPos;

        direction.x = 0; direction.y = 0;
    }

     internal void DirectionChecker()
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();

        if (angle < -135 || angle >135)
        {
            right = true;
        } else right = false;

        if(angle > 45 && angle < 135)
        {
            down = true;
        } else down = false;

        if (angle > -45 && angle < 45)
        {
            left = true;
        } else left = false;

        if (angle < -45 && angle > -135)
        {
            up = true;
        } else up = false;

        direction.x = 0; direction.y = 0;

    }
}
