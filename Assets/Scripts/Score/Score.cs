using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    // Singleton pointer
    public static Score Instance { get; private set; }
    private int score = 0;

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ScoreUI.Instance.UpdateUI(score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        ScoreUI.Instance.UpdateUI(score);
    }
}
