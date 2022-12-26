using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private int _Score;
    [SerializeField]
    private Text _ScoreText;

    [SerializeField]
    private bool _aScore;

    public int ScorePoint
        { 
          get { return _Score; }
          set { _Score = value; }
        }



    private void Start()
    {
        _Score = 0;
        _ScoreText.text = $"{_Score}";
    }

    public void Updete()
    {
        _ScoreText.text = $"{_Score}";
    }


}
