using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyAnimationConrtoller : MonoBehaviour {
    
    const int STATE_IDLE = 0;
    const int STATE_WALK = 1;
    const int STATE_JUMP = 2;
    const int STATE_FALL = 3;
    const int STATE_KNOCKED = 4;
    int _currentAnimationState = STATE_IDLE;
    string _currentDirection = "left";

    Animator animator;
    public BunnyController bunnyController;

    // Use this for initialization
    void Start () {
        animator = this.GetComponentInChildren<Animator>();
        //physicsController = this.GetComponent<NinjaController>();
    }
	
	// Update is called once per frame
    void Update()
    {
        bool _isGrounded = !bunnyController.IsInAir && !bunnyController.IsOnWall;
        if (Input.GetKey("right"))
        {
            changeDirection("right");
            if (_isGrounded)
                changeState(STATE_WALK);
        }
        else if (Input.GetKey("left"))
        {
            changeDirection("left");

            if (_isGrounded)
                changeState(STATE_WALK);
        }
        else
        {
            if (_isGrounded)
                changeState(STATE_IDLE);
        }

        if (!_isGrounded)
        {
            Vector2 vel = bunnyController.Velocity;
            //Debug.Log(vel); 
            if (vel.y > 0)
            {
                changeState(STATE_JUMP);
            }
            else if(vel.y < 0)
            {
                changeState(STATE_FALL);
            }
            //changeState(vel.y > 0.01 ? STATE_JUMP : STATE_FALL);
        }
    }

    //--------------------------------------
    // Change the players animation state
    //--------------------------------------
    void changeState(int state)
    {

        if (_currentAnimationState == state)
            return;

        switch (state)
        {

            case STATE_WALK:
                animator.SetInteger("state", STATE_WALK);
                break;

            case STATE_JUMP:
                animator.SetInteger("state", STATE_JUMP);
                break;

            case STATE_IDLE:
                animator.SetInteger("state", STATE_IDLE);
                break;

            case STATE_FALL:
                animator.SetInteger("state", STATE_FALL);
                break;

            case STATE_KNOCKED:
                animator.SetInteger("state", STATE_KNOCKED);
                break;

        }

        _currentAnimationState = state;
    }

    //--------------------------------------
    // Flip player sprite for left/right walking
    //--------------------------------------
    void changeDirection(string direction)
    {
        if (_currentDirection != direction)
        {
            if (direction == "right")
            {
                transform.Rotate(0, 180, 0);
                _currentDirection = "right";
            }
            else if (direction == "left")
            {
                transform.Rotate(0, -180, 0);
                _currentDirection = "left";
            }
        }
    }
}
