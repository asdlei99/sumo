using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumoSpawner : MonoBehaviour
{
    #region Variables

    // Singleton pointer
    public static SumoSpawner Instance { get; private set; }

    [SerializeField]
    private List<Transform> spawnLocations;

    [SerializeField]
    private GameObject npcPrefab;

    [SerializeField]
    private GameObject playerPrefab;

    private bool isFirstSpawn = true;
    #endregion

    #region Methods

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
        foreach(Transform location in spawnLocations)
        {
            if(isFirstSpawn)
            {
                Sumos.Instance.SumosInGame.Add(Instantiate(playerPrefab, location.position, location.rotation));
                isFirstSpawn = false;
            }
            else
            {
                Sumos.Instance.SumosInGame.Add(Instantiate(npcPrefab, location.position, location.rotation));
            }
        }   
    }
    #endregion
}
