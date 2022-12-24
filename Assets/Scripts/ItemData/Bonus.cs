using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bonus : MonoBehaviour
{
    [SerializeField] float _defaultGravity;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody2D;
    [SerializeField] int _heavy = 0;
    int _point = 0;
    float _bourst = 0;
    Vector2 _velocity = Vector2.zero;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _velocity = Vector2.zero;
        _bourst = 1 + ((float)_heavy / 100);
    }

    // Update is called once per frame
    void Update()
    {
        _velocity.y += (_defaultGravity * _bourst) * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _velocity;
    }
}
