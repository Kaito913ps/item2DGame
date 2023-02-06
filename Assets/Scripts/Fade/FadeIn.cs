using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Purchasing;

public class FadeIn : MonoBehaviour
{
    [SerializeField] Scene _scene;
    //�����ȍ����摜
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
        //�摜���A�N�e�B�u�ɂ���
        _image.gameObject.SetActive(true);

        Color c = _image.color;
        c.a = 0f;
        //�摜�̕s�����x��1�ɂ���
        _image.color = c;

        while(_time < timer)
        {
            _time += Time.deltaTime;
            c.a += _fadetime;
            //�摜�̕s�����x���グ��
            _image.color = c;
            yield return null;
            //�s�����x��0�ȉ��̂Ƃ�
            if(c.a >= 255f)
            {
                //�J��Ԃ��I��
                break;
            }
        }
        _scene.LoadScenes();
    }
}
