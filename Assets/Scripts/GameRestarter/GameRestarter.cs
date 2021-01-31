using System.Collections;
using UnityEngine;

namespace Sumo.GameStateManagement
{
    public class GameRestarter : MonoBehaviour
    {
        // Singleton pointer
        public static GameRestarter Instance { get; private set; }

        private void Awake()
        {
            // Set this class as Singleton
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        public void Restart(bool isWin)
        {
            StartCoroutine(RestartCoroutine(isWin));
        }

        public IEnumerator RestartCoroutine(bool isWin)
        {
            // Hide in game ui
            Sumo.UI.InGameUI.Instance.Hide();

            // Destroy all enhancers in the scene.
            DestroyEnhancers();

            // Destroy all sumos in the scene.
            DestroySumos();

            // Display game over ui
            Sumo.UI.GameStarterUI.Instance.DisplayGameOverUI(isWin);

            // Wait for 2 seconds to display ui.
            yield return new WaitForSeconds(2f);

            // Remove game over ui
            Sumo.UI.GameStarterUI.Instance.RemoveGameOverUI();

            // Show in game ui
            Sumo.UI.InGameUI.Instance.Show();

            // Spawn enhancers back
            Sumo.EnhancerManagement.EnhancerSpawner.Instance.InitialSpawn();

            // Spawn sumos back
            Sumo.SumoManagement.SumoSpawner.Instance.InitialSpawn();

            // Reset timer
            Sumo.TimeManagement.Timer.Instance.Reset();
        
        }

        private void DestroyEnhancers()
        {
            // Destroy each enhancer in the list.
            foreach (GameObject enhancer in Sumo.EnhancerManagement.EnhancerContainer.Instance.enchancers)
                Destroy(enhancer);
        }

        private void DestroySumos()
        {
            // Destroy each enhancer in the list.
            foreach (GameObject sumo in Sumo.SumoManagement.SumoContainer.Instance.sumos)
                Destroy(sumo);
        }

    
    }
}
