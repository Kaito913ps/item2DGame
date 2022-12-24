using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CreateItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField, Tooltip("重さ"), Range(0, 1000)] int _heavy;
    [SerializeField, Tooltip("獲得ポイント"), Range(0, 10000)] int _score;
    [SerializeField, Tooltip("画像データ")] Sprite _sprite;
    [SerializeField, Tooltip("画像の大きさ")] Vector3 _scale;

    public int Heavy { get => _heavy; }
    public int Score { get => _score; }
    public Sprite Sprite { get => _sprite; }
    public Vector3 Scale { get => _scale; }
}
