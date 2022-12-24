using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sr;

    [SerializeField] private float moveForce = 10f;
    [SerializeField] private float jumpForce = 12f;

    private float _movementX;

    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMove();
        
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    private void PlayerMove()
    {
        _movementX = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);

        _rb.velocity = new Vector2(_movementX * moveForce, _rb.velocity.y);
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);

            _isGrounded = false;
        }
    }

    private void AnimatePlayer()
    {
        if (_movementX>0)
        {
            _anim.SetBool(TagManager.PLAYER_ANIM_IS_WALKING_PARAMETR,true);
            _sr.flipX = false;
        }else if (_movementX < 0)
        {
            _anim.SetBool(TagManager.PLAYER_ANIM_IS_WALKING_PARAMETR,true);
            _sr.flipX = true;
        }
        else
        {
            _anim.SetBool(TagManager.PLAYER_ANIM_IS_WALKING_PARAMETR,false);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(TagManager.GROUND_TAG))
        {
            _isGrounded = true;
        }

        if (col.gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
