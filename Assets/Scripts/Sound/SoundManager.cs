using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] _audioSourceList;
    void Start()
    {
        //audioSource配列の数だけAudioSourceを自分自信に生成して配列に格納
        for(var i = 0; i < _audioSourceList.Length; i++)
        {
            _audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }
    }

   //未使用のAudioSourceの取得全て使用中の場合はnullを返却
   private AudioSource GetUnusedAudioSource()
    {
        for(var i = 0; i < _audioSourceList.Length; ++i)
        {
            if (_audioSourceList[i].isPlaying == false)
                return _audioSourceList[i];
        }
        //未使用のAudioSourceは見つかりませんでした
        return null;
    }

    //指定されたAudioClipを未使用のAudioSourceで再生
    public void Play(AudioClip clip)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = clip;
        audioSource.Play();
    }
}
