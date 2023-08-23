using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : LocalSingleton<PlayerController>
{
    LevelManager levelManagerScript;
    SoundManager soundManagerScript;
    UIManager uiManagerScript;
    PlayerHealt playerHealtScript;
    Delay delayScript;

    Rigidbody2D rb;
    SpriteRenderer playerRenderer;
    Animator animator;
    private float horizontalMove;
    [SerializeField] private float playerSpeed = 10f;


    void Awake()
    {
        levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManager>();
        playerHealtScript = GameObject.Find("LevelManager").GetComponent<PlayerHealt>();
        delayScript = GameObject.Find("LevelManager").GetComponent<Delay>();
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

 
    private void FixedUpdate()
    {
        PlayerControl();
        PlayerDeath();
    }

    void PlayerControl()
    {
        
        if (levelManagerScript.canMove)
        {
            horizontalMove = (Input.GetAxis("Horizontal"));
            rb.velocity = new Vector2(horizontalMove * playerSpeed, rb.velocity.y);
        }

        if (horizontalMove > 0)
        {
            playerRenderer.flipX = false;
            animator.SetBool("isWalking", true);
        }
        else if (horizontalMove < 0)
        {
            playerRenderer.flipX = true;
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void PlayerDeath()
    {
        if (transform.position.y < -7)
        {   
            gameObject.SetActive(false);
            soundManagerScript.DeathByFall();
            playerHealtScript.Lives();

            if(delayScript.delayTime)
            {
                delayScript.DelayNewTime();
            }
        }
    }
}



