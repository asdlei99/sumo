using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sumos : MonoBehaviour
{
    // Singleton pointer
    public static Sumos Instance { get; private set; }

    public List<GameObject> SumosInGame = new List<GameObject>();

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
