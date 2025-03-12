using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;


    private void Awake()
    {
        ScoreKeeper.instance.OnScoreChanged += UpdateScoreText; 
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "FOOD: " + ScoreKeeper.instance.GetScore().ToString("00") + "/30";
    }
}
