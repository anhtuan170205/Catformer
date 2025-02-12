using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;
    SceneLoader sceneLoader;
    void Awake()
    {
        ManageSingleton();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    int score = 0;
    
    public int GetScore()
    {
        return score;
    }
    public void AddScore(int points)
    {
        score += points;
        AudioPlayer.instance.PlayEatingClip();
        Mathf.Clamp(score, 0, int.MaxValue);
    }
    public void ResetScore()
    {
        score = 0;
    }
}
