using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //�����G�t�F�N�g���������ꂽ���ɌĂяo�����֐�
    void Start()
    {
        var particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.main.duration);
    }
}
