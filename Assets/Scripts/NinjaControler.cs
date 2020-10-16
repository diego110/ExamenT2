using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaControler : MonoBehaviour
{
    private const int ANIMATION_Idle = 0;
    private const int ANIMATION_Run = 1;
    private const int ANIMATION_Jump = 2;
    private const int ANIMATION_Throw = 3;


    public float velocity = 10f;
    private float jumpForce = 30f;
    private Rigidbody2D rb;
    private Animator _animator;
    private SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        _animator.SetInteger("Estado", ANIMATION_Idle);

        if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            _animator.SetInteger("Estado", ANIMATION_Run);
        }

        if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            _animator.SetInteger("Estado", ANIMATION_Run);

        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            _animator.SetInteger("Estado", ANIMATION_Jump);
        }

        if (UnityEngine.Input.GetKeyUp(KeyCode.X))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _animator.SetInteger("Estado", ANIMATION_Throw);
        }
    }
}
