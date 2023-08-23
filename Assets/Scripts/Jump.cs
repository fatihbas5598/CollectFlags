using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    LevelManager levelManagerScript;
    SoundManager soundManagerScript;
    
    Rigidbody2D rb;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private float radius;
    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityScale;


    void Start()
    {
        levelManagerScript = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded() && levelManagerScript.canMove)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            soundManagerScript.Jump();
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    
    }
    

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }

}
