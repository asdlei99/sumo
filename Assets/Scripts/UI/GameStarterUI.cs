using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sumo.UI
{
    public class GameStarterUI : MonoBehaviour
    {
        #region
        // Singleton pointer
        public static GameStarterUI Instance { get; private set; }

        private void Awake()
        {
            // Set this class as Singleton
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        #endregion

        [SerializeField]
        private GameObject winUIPrefab;

        [SerializeField]
        private GameObject loseUIPrefab;

        private GameObject spawnedUI;

        public void DisplayGameOverUI(bool isWin)
        {
            if (isWin)
                spawnedUI = Instantiate(winUIPrefab);
            else
                spawnedUI = Instantiate(loseUIPrefab);
        }

        public void RemoveGameOverUI()
        {
            if (spawnedUI == null)
                Debug.LogError("Game over ui is null!");

            Destroy(spawnedUI);

        }
    }
}