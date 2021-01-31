using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    // Singleton pointer
    public static TimerUI Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI timerText;

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.Instance.RemainingDuration > 0)
            timerText.text = Timer.Instance.RemainingDuration.ToString("F0");
        else
            timerText.text = "0";

    }
}
