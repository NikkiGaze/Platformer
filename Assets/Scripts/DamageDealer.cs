using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _isOneTime = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.TryGetComponent(out Health healthComponent))
        {
            healthComponent.TakeDamage(_damage);
        }

        if (_isOneTime)
        {
            Destroy(gameObject);
        }
    }
}
