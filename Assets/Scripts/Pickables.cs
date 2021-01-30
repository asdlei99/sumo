using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickables : MonoBehaviour
{
    // Singleton pointer
    public static Pickables Instance { get; private set; }

    public List<GameObject> pickablesInGame = new List<GameObject>();
    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
