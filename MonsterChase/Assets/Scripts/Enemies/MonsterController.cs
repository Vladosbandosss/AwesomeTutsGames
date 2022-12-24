using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    [HideInInspector] public float moveSpeed;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        moveSpeed = 7f;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
    }
}
