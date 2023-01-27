using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazure : MonoBehaviour
{
    [SerializeField] float _defaultGravity;
    [SerializeField] private Explosion _exception;

    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rigidbody;
    [SerializeField] int _heavy = 0;
    int _point = 0;
    float _boust = 0;
    Vector2 _velocity = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _velocity = Vector2.zero;
        _boust = 1 + ((float)_heavy / 100);
    }

    // Update is called once per frame
    void Update()
    {
        _velocity.y += (_defaultGravity * _boust) * Time.deltaTime;
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_exception, collision.transform.localPosition, Quaternion.identity);
        }
    }
}
