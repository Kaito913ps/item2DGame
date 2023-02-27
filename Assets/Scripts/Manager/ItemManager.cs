using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject _itemPrefab;
    //データ
    [SerializeField] List<ItemData> _itemDatas;

    [SerializeField] GameObject _minObj;
    [SerializeField] GameObject _maxObj;
    [SerializeField] float _offsetY;

    [SerializeField] float _interval;
    [SerializeField] GameObject[] _trap;
    [SerializeField] GameObject[] _rea;
    [SerializeField] float _trapinterval;
    [SerializeField] float _bonusinterval;

    float minX;
    float maxX;

    float _bonusTime = 0;
    float _trapTime;
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
            _trapTime += Time.deltaTime;
            _bonusTime += Time.deltaTime;

            if (_fallTime > _interval)
            {
                _fallTime -= _interval;
                //item
                CreateItem();
            }

            if(_trapTime > _trapinterval)
            {
                _trapTime -= _trapinterval;
                CreateTrap();
            }

            if (_bonusTime > _bonusinterval)
            {
                _bonusTime -= _bonusinterval;
                CreateRareItem();
            }
        }
    }
    /// <summary>
    /// トラップを生成
    /// </summary>
    void CreateTrap()
    {
        float posX = Random.Range(minX, maxX);
        int index = Random.Range(0, _trap.Length);
        Instantiate(_trap[index], new Vector2(posX, _offsetY), Quaternion.identity);
    }



    void CreateRareItem()
    {
        float posX = Random.Range(minX, maxX);
        int index = Random.Range(0, _trap.Length);
        Instantiate(_rea[index], new Vector2(posX, _offsetY), Quaternion.identity);
    }
    /// <summary>
    /// 通常のアイテムを生成
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
