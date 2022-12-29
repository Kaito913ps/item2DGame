using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _playerMinPos;
    [SerializeField] private float _playerMaxPos;
    [SerializeField] Text _scoretext;
    [SerializeField] SoundManager _soundManager;
   

    public static int score;

    private Animator _animator;
    private Rigidbody2D _rb2D;
    private bool _atari = false;
    private bool _hazure = false;
    private int _playerPoint;

    bool _facingRight = true;

    


    void Start()
    {
        score = 0;
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();


    }

   
    void Update()
    {
        _scoretext.text = $"{score + _playerPoint}";
        if (GameState.Instance.CurrentState == State.Play && !_hazure)
        {
            Move();

            kyorihatei();
        }
    }

    private void Move()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
       

        _rb2D.velocity = new Vector2(horizontal * _speed, 0);
        var currentScale = transform.localScale;
        if (horizontal < 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (horizontal > 0)
        {
            transform.localScale = new Vector3( 1, 1, 1);
        }
        _animator.SetFloat("xhorizontal",Mathf.Abs(_rb2D.velocity.x));
    }

    void kyorihatei()
    {
        if(!_hazure)
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

    public void TotalScore()
    {
        if (_atari)
        {
            score += _playerPoint * 2;
            //_atari = false;
        }
        else score += _playerPoint;
        _playerPoint = 0;
        _rb2D.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_hazure)
        {
            if (other.TryGetComponent<Item>(out var item))
            {
                //oto
                // _soundManager.Play();
                _playerPoint += item.Score;
                Destroy(other.gameObject);
            }
        }

         if (other.gameObject.CompareTag("Gas") && !_hazure)
        {
            score -= 100;
            if (score < 0) score = 0;
            Destroy(other.gameObject);
            StartCoroutine(Delay());
        }

         if (other.gameObject.CompareTag("Hazure") && !_hazure)
        {
            score -= 500;
            if (score < 0) score = 0;
            Destroy(other.gameObject);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        _rb2D.velocity = Vector2.zero;
        _hazure = true;
        yield return new WaitForSeconds(2.0f);
        _hazure = false;
    }
}
