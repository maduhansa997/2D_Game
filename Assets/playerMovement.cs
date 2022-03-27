using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    
    private Rigidbody2D rB;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float runningSpeed = 10;

    private enum MovementState { idle, running, jumping, falling }
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
             dirX = Input.GetAxisRaw("Horizontal");
        rB.velocity = new Vector2(dirX * runningSpeed, rB.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            //jumpSound.Play();
            rB.velocity = new Vector2(rB.velocity.x,jumpForce);
            Debug.Log("111111111111111111111111111");
        }

        CharactorAnimationUpdate();
    }

    private void CharactorAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rB.velocity.y > .1)
        {
            state = MovementState.jumping;
        }
        else if (rB.velocity.y < -.1)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}