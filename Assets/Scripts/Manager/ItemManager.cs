using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject _itemPrefab;
    //�f�[�^
    [SerializeField] List<ItemData> _itemDatas;

    [SerializeField] GameObject _minObj;
    [SerializeField] GameObject _maxObj;
    [SerializeField] float _offsetY;

    [SerializeField] float _interval;
    [SerializeField] GameObject[] _bonus;
    [SerializeField] float _bonusinterval;

    float minX;
    float maxX;

    float _bonusTime = 0;

    float _fallTime;
    void Start()
    {
        minX = _minObj.transform.position.x;
        maxX = _maxObj.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameState.Instance.CurrentState == State.Play)
        {
            _fallTime += Time.deltaTime;
            _bonusTime += Time.deltaTime;

            if (_fallTime > _interval)
            {
                _fallTime -= _interval;
                //item
                CreateItem();
            }
            if (_bonusTime > _bonusinterval)
            {
                _bonusTime -= _bonusinterval;
                //�{�[�i�X
                CreateBonus();
            }
        }
    }
    /// <summary>
    /// �{�[�i�X�A�C�e���𐶐�
    /// </summary>
    void CreateBonus()
    {
        float posX = Random.Range(minX, maxX);
        int index = Random.Range(0, _bonus.Length);
        Instantiate(_bonus[index], new Vector2(posX, _offsetY), Quaternion.identity);
    }
    /// <summary>
    /// �ʏ�̃A�C�e���𐶐�
    /// </summary>
    void CreateItem()
    {
        float posX = Random.Range(minX, maxX);
        GameObject tmp = Instantiate(_itemPrefab, new Vector2(posX,_offsetY),Quaternion.identity);

        if (tmp.TryGetComponent(out Item item))
        {
            int index = Random.Range(0, _itemDatas.Count);
            item.Init(_itemDatas[index]);
        }
        else Debug.LogError($"Cant GetComponent[Item]");
    }
}
