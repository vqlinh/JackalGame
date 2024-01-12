using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerlv2 : MonoBehaviour
{
    public float MoveSpeed;
    Vector2 movement;
    public Rigidbody2D rb;
    public Animator animator;
    // Start is called before the first frame update
    public float valX;
    public float valY;
    public bool checkIdle = false;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if(movement.x == 0 && movement.y == 0) { 
            
            checkIdle = true;
        }
        else
        {
            checkIdle = false;
            valX = movement.x;
            valY = movement.y;
        }

        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);    
        animator.SetFloat("ValX", valX);
        animator.SetFloat("ValY", valY);
        animator.SetBool("checkIdle", checkIdle);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
