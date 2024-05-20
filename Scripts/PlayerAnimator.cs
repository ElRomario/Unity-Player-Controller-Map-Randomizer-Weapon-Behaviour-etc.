using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
                      

        if (playerMovement.moveDir.x != 0)
        {
            animator.SetBool("IsMovingHorizontal", true);
            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("IsMovingHorizontal", false);
            SpriteDirectionChecker();
        }
        if (playerMovement.moveDir.y > 0)
        {
            animator.SetBool("IsMovingUp", true);
            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("IsMovingUp", false);
            SpriteDirectionChecker();
        }

        if (playerMovement.moveDir.y < 0)
        {
            animator.SetBool("IsMovingDown", true);
            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("IsMovingDown", false);
            SpriteDirectionChecker();
        }

        

    }
    void SpriteDirectionChecker()
    {
        spriteRenderer.flipX = playerMovement.moveDir.x > 0 ? false : true;
    }

}
