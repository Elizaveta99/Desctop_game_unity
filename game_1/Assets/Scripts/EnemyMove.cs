using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float maxSpeed = 10f;
    public bool flag = false;

    private bool isFacingRight = true;
    private float move = 1;

    private Rigidbody2D rigi;
    private Animator anim;


    private int stepsAmount = 0;

	private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        stepsAmount++;
        if (stepsAmount == 81) 
        {
            stepsAmount = 0;
            move *= -1;
        }
        
        anim.SetFloat("Speed", Mathf.Abs(move));

        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);
        if (move > 0 && !isFacingRight && !flag)
            Flip();
        else if (move < 0 && isFacingRight && !flag)
            Flip();
    }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
