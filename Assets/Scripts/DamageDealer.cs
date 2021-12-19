using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health healthComponent))
        {
            healthComponent.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
