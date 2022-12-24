using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    [SerializeField] float _defaultGravity;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody2D;
    int _heavy = 0;
    int _score = 0;
    float _buust = 0;
    Vector2 _velocity = Vector2.zero;

    public int Score => _score;

    private void Start()
    {
        _velocity = Vector2.zero;
        _buust = 1 + ((float)_heavy / 100);
    }
    void Update()
    {
        _velocity.y += (_defaultGravity * _buust) * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _velocity;
    }

    public void Init(ItemData data)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        transform.localScale = data.Scale;
        _spriteRenderer.sprite = data.Sprite;
        _heavy = data.Heavy;
        _score = data.Score;
    }
}
