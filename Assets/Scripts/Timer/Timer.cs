using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Singleton pointer
    public static Timer Instance { get; private set; }

    // Specifies match duration. (in seconds)
    [SerializeField]
    private float matchDurationInSeconds = 60f;
    
    // Holds current time
    private float currentTime = 0f;
    public float CurrentTime { get { return currentTime; } }

    // Holds remaing duration (time). 
    public float RemainingDuration { get { return matchDurationInSeconds - currentTime; } }

    private bool isStopped = false;
 

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isStopped)
        {
            currentTime += Time.deltaTime;

            RestartGameOnTimerUp();
        }
    }

    public void Reset()
    {
        currentTime = 0f;
        isStopped = false;
    }
    public void RestartGameOnTimerUp()
    {
        if (RemainingDuration < 0)
        {
            isStopped = true;

            // Check if player won.
            bool isWin = false;
            if (SumoContainer.Instance.WinnerSumo().tag == "Player")
                isWin = true;

            GameRestarter.Instance.Restart(isWin);
        }
    }
}
