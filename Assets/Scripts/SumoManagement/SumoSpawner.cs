using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo.SumoManagement
{
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
            InitialSpawn();
        }

        public void InitialSpawn()
        {
            bool isFirstSpawn = true;

            foreach (Transform location in spawnLocations)
            {
                if (isFirstSpawn)
                {
                    SumoContainer.Instance.sumos.Add(Instantiate(playerPrefab, location.position, location.rotation));
                    isFirstSpawn = false;
                }
                else
                {
                    SumoContainer.Instance.sumos.Add(Instantiate(npcPrefab, location.position, location.rotation));
                }
            }
        }
        #endregion
    }
}
