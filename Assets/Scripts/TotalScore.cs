using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour
{
    [SerializeField] Text _totalScore;
    int _score;
    void Start()
    {
        _score = PlayerMovement.score;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(_score);
    }

    // Update is called once per frame
    void Update()
    {
        _totalScore.text = $"{_score}";
    }
}
