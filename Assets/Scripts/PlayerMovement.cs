using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _playerMinPos;
    [SerializeField] private float _playerMaxPos;
    [SerializeField] Text _scoretext;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] private Explosion _exception;
    [SerializeField] private Explosion _gusexception;


    public static int score;

    private Animator _animator;
    private Rigidbody2D _rb2D;
    private bool _atari = false;
    private bool _hazure = false;
    private int _playerPoint;

    bool _facingRight = true;

    /// <summary> マテリアルの色パラメータのID</summary>
    private static readonly int PROPERTY_COLOR = Shader.PropertyToID("_Color");

    /// <summary>モデルのRenderer</summary>
    [SerializeField]
    private Renderer _renderer;

    /// <summary>モデルのマテリアルの複製</summary>
    private Material _material;

    private Sequence _seq;

    private void Awake()
    {
        // materialにアクセスして自動生成されるマテリアルを保持
        _material = _renderer.material;
    }

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
                SoundManager.Instance.PlaySE(SESoundData.SE.Item);
                _playerPoint += item.Score;
                Destroy(other.gameObject);
            }
        }

         if (other.gameObject.CompareTag("Gas") && !_hazure)
        {
            score -= 100;
            //if (score < 0) score = 0;
           
            
            Destroy(other.gameObject);
            HitFadeBlink(Color.red);
            Instantiate(_gusexception, other.transform.localPosition, Quaternion.identity);
            SoundManager.Instance.PlaySE(SESoundData.SE.Damage);
            StartCoroutine(Delay());
        }

         if (other.gameObject.CompareTag("Hazure") && !_hazure)
        {
            score -= 500;
            //if (score < 0) score = 0;
            SoundManager.Instance.PlaySE(SESoundData.SE.Bakudan);
            Destroy(other.gameObject);
            HitFadeBlink(Color.red);
            Instantiate(_exception, other.transform.localPosition,Quaternion.identity);
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

    /// <summary>カラー乗算によるダメージ演出再生</summary>
    /// <param name="color"></param>
    private void HitFadeBlink(Color color)
    {
        _seq?.Kill();
        _seq = DOTween.Sequence();
        _seq.Append(DOTween.To(() => Color.white, c => _material.SetColor(PROPERTY_COLOR, c), color, 0.1f));
        _seq.Append(DOTween.To(() => color, c => _material.SetColor(PROPERTY_COLOR, c), Color.white, 0.1f));
        _seq.Play();
    }
}
