using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    //透明な黒い画像
    [SerializeField] Image _img;
    [SerializeField] float _timer = 2f;

    float _time;
    [SerializeField] float _fadetime = 0.02f;

    void Start()
    {
        StartCoroutine(Age());
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
    }

    IEnumerator Age()
    {
        //画像をアクティブにする
        _img.gameObject.SetActive(true);

        Color c = _img.color;
        c.a = 1f;
        //画像の不透明度を1にする
        _img.color = c;

        while(_time < _timer)
        {
            _time += Time.deltaTime;
            c.a -= _fadetime;
            //画像の不透明度を上げる
            _img.color = c;
            yield return null;
            if(c.a <= 0f)
            {
                c.a = 0f;
                //不透明度を0
                _img.color = c;
                break;//繰り返し終了
            }
        }
        _img.gameObject.SetActive(false);
    }
}
