using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    int _score = 0;

    [SerializeField] int currentscore;
    [SerializeField] TextMeshProUGUI _TextToUpdate;
    [SerializeField] TextMeshProUGUI _ScoreText;
    [SerializeField] TextMeshProUGUI _PotionText;




    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    internal void AddScore(int count)
    {
        _score += count;
        _scoreText.text = _score.ToString(); // Si il y'a 100 à l' intérieur transformation en texte 100

        Debug.Log($" Score : {_score}");
    }


}