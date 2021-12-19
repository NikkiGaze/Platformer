using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";
    private const string JumpInput = "Jump";

    private PlayerMovement _playerMovement = null;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float horizontalDirection = Input.GetAxis(HorizontalInput);
        bool isJump = Input.GetButtonDown(JumpInput);
        _playerMovement.Move(horizontalDirection, isJump);
    }
}
