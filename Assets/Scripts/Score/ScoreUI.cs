using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    // Singleton pointer
    public static ScoreUI Instance { get; private set; }

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
