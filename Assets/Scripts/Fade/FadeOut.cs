using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    //�����ȍ����摜
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
        //�摜���A�N�e�B�u�ɂ���
        _img.gameObject.SetActive(true);

        Color c = _img.color;
        c.a = 1f;
        //�摜�̕s�����x��1�ɂ���
        _img.color = c;

        while(_time < _timer)
        {
            _time += Time.deltaTime;
            c.a -= _fadetime;
            //�摜�̕s�����x���グ��
            _img.color = c;
            yield return null;
            if(c.a <= 0f)
            {
                c.a = 0f;
                //�s�����x��0
                _img.color = c;
                break;//�J��Ԃ��I��
            }
        }
        _img.gameObject.SetActive(false);
    }
}
