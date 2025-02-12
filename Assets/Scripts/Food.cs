using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<ScoreKeeper>().AddScore(1);
            Debug.Log("Food eaten");
            Debug.Log("Score: " + FindObjectOfType<ScoreKeeper>().GetScore());
            Destroy(gameObject);
        }
    }
}
