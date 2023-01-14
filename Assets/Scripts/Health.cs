using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private int _maxHP;
    [SerializeField] private bool _isPlayer;
    private int _currentHP;


    private void Start()
    {
        _currentHP = _maxHP;
    }

    public void TakeDamage(int count)
    {
        _currentHP -= count;

        if (_healthBar)
        {
            SpriteRenderer renderer = _healthBar.GetComponent<SpriteRenderer>();
            var rendererColor = renderer.color;
            rendererColor.a = (float)_currentHP / _maxHP;
            renderer.color = rendererColor;
        }

        if (_currentHP <= 0)
        {
            Destroy(gameObject);

            if (_isPlayer)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
