using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    private void Start()
    {
        PrintScore();
        GameData.ScoreChanged += GameData_ScoreChanged;
    }

    private void PrintScore()
    {
        _score.text = $"Score: {GameData.Score}";
    }

    private void GameData_ScoreChanged(int score)
    {
        _score.text = $"Score: {score}";
    }

}
