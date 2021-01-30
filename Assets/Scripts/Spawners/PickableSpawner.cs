using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableSpawner : MonoBehaviour
{
    // Singleton pointer
    public static PickableSpawner Instance { get; private set; }

    [SerializeField]
    private GameObject pickablePrefable;

    [SerializeField]
    private float radiusToSpawnIn = 10f;

    [SerializeField]
    private int numberOfObjectsToSpawn = 5;

    private void Awake()
    {
        // Set this class as Singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Spawn pickable
        for(int index = 0; index < numberOfObjectsToSpawn; index++)
        {
            float randX = Random.Range(-radiusToSpawnIn, radiusToSpawnIn);
            float randZ = Random.Range(-radiusToSpawnIn, radiusToSpawnIn);
            Pickables.Instance.pickablesInGame.Add(Instantiate(pickablePrefable, new Vector3(randX, 2, randZ), Quaternion.Euler(-90, 0, 0)));
        }
    }

    public void Spawn()
    {
        float randX = Random.Range(-radiusToSpawnIn, radiusToSpawnIn);
        float randZ = Random.Range(-radiusToSpawnIn, radiusToSpawnIn);
        Pickables.Instance.pickablesInGame.Add(Instantiate(pickablePrefable, new Vector3(randX, 2, randZ), Quaternion.Euler(-90, 0, 0)));
    }
}
