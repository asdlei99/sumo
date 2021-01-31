using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoContainer : MonoBehaviour
{
    // Singleton pointer
    public static SumoContainer Instance { get; private set; }

    public List<GameObject> sumos = new List<GameObject>();

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject WinnerSumo()
    {
        // Get winner sumo
        GameObject winnerSumo = null;
        foreach (GameObject sumo in SumoContainer.Instance.sumos)
        {
            if (sumo == null)
                continue;

            if (winnerSumo == null)
                winnerSumo = sumo;

            if (sumo.GetComponent<SumoScore>().Score > winnerSumo.GetComponent<SumoScore>().Score)
            {
                winnerSumo = sumo;
            }
        }
        return winnerSumo;
    }
}
