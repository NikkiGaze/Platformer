﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _horizontalSpeed;

    [Header("Settings")] 
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Transform _groundCollider;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpOffset;
    
    private bool _isGrounded = false;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(
            _groundCollider.transform.position, _jumpOffset, _groundLayer);
    }

    public void Move(float direction, bool isJump)
    {
        if (isJump)
        {
            Jump();
        }
        
        if (Mathf.Abs(direction) > 0.01f)
        {
            HorizontalMovement(direction);
        }
        
        UpdateAnimations(direction, isJump);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
    
    private void HorizontalMovement(float direction)
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector2(_curve.Evaluate(direction) * _horizontalSpeed, _rigidbody.velocity.y);
        }
    }

    private void UpdateAnimations(float direction, bool isJump)
    {
        if (_rigidbody.velocity.y < 0.01 && !isJump)
        {
            _animator.SetBool(IsJumping, false);
        }
        else
        {
            _animator.SetBool(IsJumping, true);
        }

        if (Mathf.Abs(direction) > 0.2f)
        {
            _animator.SetBool(IsRunning, true);
        }
        else
        {
            _animator.SetBool(IsRunning, false);
        }
    }
}
