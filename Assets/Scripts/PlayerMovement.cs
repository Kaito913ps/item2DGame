using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _playerMinPos;
    [SerializeField] private float _playerMaxPos;



    private Rigidbody2D _rb2D;
    private bool hasDaikyou;


    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if(!hasDaikyou)
        {
            var horizontal = Input.GetAxisRaw("Horizontal");

            _rb2D.velocity = new Vector2(horizontal * _speed, 0);

            kyorihatei();
        }
    }

    void kyorihatei()
    {
        if(!hasDaikyou)
        {
            Vector3 pos = transform.position;
            if(pos.x < _playerMinPos)
            {
                pos.x = _playerMinPos;
                transform.position = pos;
            }
            else if(pos.x > _playerMaxPos)
            {
                pos.x = _playerMaxPos;
                transform.position = pos;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Item>(out var item))
        {
            Destroy(other.gameObject);
        }
    }
}
