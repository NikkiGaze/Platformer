using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string VerticalInput = "Vertical";
    private const string JumpInput = "Jump";
    private const string FireInput = "Fire1";

    private PlayerMovement _playerMovement;
    private Shooter _shooter;
    void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooter = GetComponent<Shooter>();
    }

    void Update()
    {
        float horizontalDirection = Input.GetAxis(HorizontalInput);
        bool isJump = Input.GetButtonDown(JumpInput);
        
        _playerMovement.Move(horizontalDirection, isJump);

        if (Input.GetButtonDown(FireInput))
        {
            _shooter.Shoot(_playerMovement.GetDirection());
        }
    }

    public void Shoot()
    {
        _shooter.Shoot(_playerMovement.GetDirection());
    }
}
