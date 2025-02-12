using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    public TextMeshProUGUI scoreText;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Update()
    {
        scoreText.text = "FOOD: " + scoreKeeper.GetScore().ToString("00") + "/30";
    }
}
