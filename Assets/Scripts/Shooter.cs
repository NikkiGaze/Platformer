using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _firePoint;
    
    public void Shoot(float direction)
    {
        GameObject newProjectile = Instantiate(_projectile, _firePoint.position, Quaternion.identity);
        Rigidbody2D rigidBody = newProjectile.GetComponent<Rigidbody2D>();

        int directionSign = 1;
        if (direction < 0)
        {
            directionSign = -1;
        }
        newProjectile.transform.localScale = new Vector2(directionSign, 1);
        rigidBody.velocity =
            new Vector2(directionSign * _speed, rigidBody.velocity.y);
    }
}
