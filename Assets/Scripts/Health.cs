using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHP;
    private int currentHP;
    private bool _isAlive;

    private void Start()
    {
        currentHP = _maxHP;
        _isAlive = true;
    }

    public void TakeDamage(int count)
    {
        currentHP -= count;
        if (currentHP <= 0)
        {
            _isAlive = false;
            Destroy(gameObject);
        }
    }
}
