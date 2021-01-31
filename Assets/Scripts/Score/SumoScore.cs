using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoScore : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    public int Score { get {return score; } }

    private void Start()
    {
        if(tag == "Player")
            ScoreUI.Instance.UpdateUI(score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (tag == "Player")
            ScoreUI.Instance.UpdateUI(score);
    }
}
