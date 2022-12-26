using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _playerMinPos;
    [SerializeField] private float _playerMaxPos;

    [SerializeField] Score score;

    private Rigidbody2D _rb2D;
    private bool _atari;
    private bool _hazure;
    private int _playerPoint;


    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if(GameState.Instance.CurrentState == State.Play && !_hazure)
        {
            var horizontal = Input.GetAxisRaw("Horizontal");

            _rb2D.velocity = new Vector2(horizontal * _speed, 0);

            kyorihatei();
        }
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
        if (_atari) score.ScorePoint += _playerPoint * 2;
        else score.ScorePoint += _playerPoint;
        _playerPoint = 0;
        _rb2D.velocity = Vector2.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_hazure)
        {
            if (other.TryGetComponent<Item>(out var item))
            {
                _playerPoint += item.Score;
                Destroy(other.gameObject);
            }

            if(other.TryGetComponent<Atari>(out var atari))
            {
                _atari = true;
                Destroy(other.gameObject);
            }

            if(other.TryGetComponent<Hazure>(out var hazure))
            {
                score.ScorePoint -= 500;
                if(score.ScorePoint < 0) score.ScorePoint = 0;
                Destroy(other.gameObject);
                StartCoroutine(Delay());
            }
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
