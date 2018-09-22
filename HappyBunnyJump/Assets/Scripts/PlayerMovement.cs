using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementDirection
    {
        None,
        Left,
        Right
    }

    public Rigidbody2D rBody;
    public TriggerHandler groundTrigger;
    public float acceleration;
    public float jumpVelocity;
    public float jumpCooldownSeconds;
    public float drag;
    public float maxMovementSpeed;

    private float lastJump = 0f;

    public bool IsGrounded { get; private set; }
    public MovementDirection Direction { get; private set; }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal");
        bool jumping = Input.GetButtonDown("Jump");
        this.IsGrounded = this.groundTrigger.IsTriggered();

        // direction
        if (movement > 0.1f)
        {
            this.Direction = MovementDirection.Right;
        }
        else if (movement < -0.1f)
        {
            this.Direction = MovementDirection.Left;
        }
        else
        {
            this.Direction = MovementDirection.None;
        }
        // acceleration (move left/right)
        if (Mathf.Abs(movement) > 0.0001f)
        {
            float speed = this.rBody.velocity.x + Mathf.Sign(movement) * this.acceleration * Time.fixedDeltaTime;
            this.rBody.velocity = new Vector2(Mathf.Sign(speed) * Mathf.Min(Mathf.Abs(speed), this.maxMovementSpeed), this.rBody.velocity.y);
        }
        // deceleration (idle brake)
        else
        {
            float deceleration = this.acceleration * Time.fixedDeltaTime;
            // 0 speed
            if (Mathf.Abs(this.rBody.velocity.x) < deceleration)
            {
                this.rBody.velocity = new Vector2(0f, this.rBody.velocity.y);
            }
            // lower speed
            else
            {
                this.rBody.velocity = new Vector2(this.rBody.velocity.x - Mathf.Sign(this.rBody.velocity.x) * deceleration, this.rBody.velocity.y);
            }
        }
        // jump
        if (this.IsGrounded && jumping && Time.time - lastJump > this.jumpCooldownSeconds)
        {
            this.rBody.velocity += new Vector2(0f, this.jumpVelocity);
        }
    }
}
