using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] string[] _startCount;
    [SerializeField] Text _countText;
    [SerializeField] string _startText;
    [SerializeField] string endText;

     float _gameMaxTime;
    [SerializeField]
    private int _minutue;
    [SerializeField]
    private float _seconds;
    private float _totalTime;

    private float _oldTime;
    [SerializeField] private Text _timeText;


    [SerializeField] FadeIn _fadeIn;
    //score
    [SerializeField] PlayerMovement _playerpoint;

    float _currentTime;
    void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Game);
        StartGame();
        _gameMaxTime = _minutue * 60 + _seconds;
        _totalTime = _minutue * 60 + _seconds;
    }

    public void StartGame()
    {
        GameState.Instance.ChangeState(State.Ready);
        StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.Instance.CurrentState == State.Play)
        {
            if(_totalTime <= 0)
            {
                return;
            }
            _totalTime -= Time.deltaTime;
            _currentTime += Time.deltaTime;

            _minutue = (int)_totalTime / 60;
            _seconds = _totalTime - _minutue * 60;

            if((int)_seconds != (int)_oldTime)
            {
                _timeText.text = $"écÇËéûä‘{_minutue:00}:{_seconds:00}";
            }
            _oldTime = _seconds;



            if(_currentTime > _gameMaxTime)
            {
                EndGame();
            }
        }
        else if(GameState.Instance.CurrentState == State.Finish)
        {
            if(Input.anyKeyDown)
            {
                _fadeIn.ClickBotton();
            }
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1.0f);
        int count = _startCount.Length;
        while(count > 0)
        {
            //âπ
          
            SoundManager.Instance.PlaySE(SESoundData.SE.Coutdown);
            _countText.text = _startCount[count - 1];
            count--;
            yield return new WaitForSeconds(1.0f);
        }
        _countText.text = _startText;
        GameState.Instance.ChangeState(State.Play);
        // _soundManager.Play();
        //énÇ‹ÇËÇÃâπ

        _countText.enabled = false;
    }

    public void EndGame()
    {
        //_score
        //èIóπÇÃâπ
        // _soundManager.Play();
        _playerpoint.TotalScore();
        _countText.enabled = true;
        _countText.text = endText;
        GameState.Instance.ChangeState(State.Finish);
    }

}
