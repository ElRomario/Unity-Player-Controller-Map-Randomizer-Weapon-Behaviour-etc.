using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    EnemyMovement enemyMovement;
    Animator animator;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        DirectionChecker();
    }

    void DirectionChecker()
    {
        if (enemyMovement.up)
        {
            animator.SetBool("IsUp", true);
        }
        else
        {
            animator.SetBool("IsUp", false);
        }

        if (enemyMovement.down)
        {
            animator.SetBool("IsDown", true);
        }
        else
        {
            animator.SetBool("IsDown", false);
        }

        if (enemyMovement.right)
        {
            animator.SetBool("IsRight", true);
        }
        else
        {
            animator.SetBool("IsRight", false);
        }

        if (enemyMovement.left)
        {
            animator.SetBool("IsLeft", true);
        }
        else
        {
            animator.SetBool("IsLeft", false);
        }
    }
   
}
