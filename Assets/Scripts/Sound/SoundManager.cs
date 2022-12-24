using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] _audioSourceList;
    void Start()
    {
        //audioSource�z��̐�����AudioSource���������M�ɐ������Ĕz��Ɋi�[
        for(var i = 0; i < _audioSourceList.Length; i++)
        {
            _audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }
    }

   //���g�p��AudioSource�̎擾�S�Ďg�p���̏ꍇ��null��ԋp
   private AudioSource GetUnusedAudioSource()
    {
        for(var i = 0; i < _audioSourceList.Length; ++i)
        {
            if (_audioSourceList[i].isPlaying == false)
                return _audioSourceList[i];
        }
        //���g�p��AudioSource�͌�����܂���ł���
        return null;
    }

    //�w�肳�ꂽAudioClip�𖢎g�p��AudioSource�ōĐ�
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //�Đ��ł��܂���ł���
        audioSource.clip = clip;
        audioSource.Play();
    }
}
