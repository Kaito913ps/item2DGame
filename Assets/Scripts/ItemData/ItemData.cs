using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CreateItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField, Tooltip("�d��"), Range(0, 1000)] int _heavy;
    [SerializeField, Tooltip("�l���|�C���g"), Range(0, 10000)] int _score;
    [SerializeField, Tooltip("�摜�f�[�^")] Sprite _sprite;
    [SerializeField, Tooltip("�摜�̑傫��")] Vector3 _scale;

    public int Heavy { get => _heavy; }
    public int Score { get => _score; }
    public Sprite Sprite { get => _sprite; }
    public Vector3 Scale { get => _scale; }
}
