using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private int _maxHP;
    private int _currentHP;
    private bool _isAlive;

    private void Start()
    {
        _currentHP = _maxHP;
        _isAlive = true;
    }

    public void TakeDamage(int count)
    {
        _currentHP -= count;
        
        SpriteRenderer renderer = _healthBar.GetComponent<SpriteRenderer>();
        var rendererColor = renderer.color;
        rendererColor.a = (float)_currentHP / _maxHP;
        renderer.color = rendererColor;
        
        if (_currentHP <= 0)
        {
            _isAlive = false;
            Destroy(gameObject);
        }
    }
}
