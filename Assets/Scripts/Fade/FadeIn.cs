using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Purchasing;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Scene _scene;
    //透明な黒い画像
    [SerializeField] Image _image;
    [SerializeField] float timer = 3f;
    float _time;
    [SerializeField] float _fadetime = 0.02f;

    public void ClickBotton()
    {
        StartCoroutine(Age());
       SoundManager.Instance.PlaySE(SESoundData.SE.TitleExit);
    }

    IEnumerator Age()
    {
        //画像をアクティブにする
        _image.gameObject.SetActive(true);

        Color c = _image.color;
        c.a = 0f;
        //画像の不透明度を1にする
        _image.color = c;

        while(_time < timer)
        {
            _time += Time.deltaTime;
            c.a += _fadetime;
            //画像の不透明度を上げる
            _image.color = c;
            yield return null;
            //不透明度が0以下のとき
            if(c.a >= 255f)
            {
                //繰り返し終了
                break;
            }
        }
        _scene.LoadScenes();
    }
}
