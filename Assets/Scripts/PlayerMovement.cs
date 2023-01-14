using System;
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
    [SerializeField] private Animator _animator;
    
    
    private bool _isGrounded = false;
    private float _direction = 0;
    private Rigidbody2D _rigidbody;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private float _input;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(
            _groundCollider.transform.position, _jumpOffset, _groundLayer);

        Move(_input, false);
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

    public float GetDirection()
    {
        return _direction;
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
    
    void HorizontalMovement(float direction)
    {
        if (_isGrounded)
        {
            _direction = Mathf.Sign(direction);
            _rigidbody.velocity = new Vector2(_curve.Evaluate(direction) * _horizontalSpeed, _rigidbody.velocity.y);
            transform.localScale = new Vector2(_direction, 1);
            
        }
    }

    public void StartMoving(float direction)
    {
        _input = direction;
    }
    
    public void StopMoving()
    {
        _input = 0.0f;
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
