using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class holds references to sumos in the scene. 
 */

namespace Sumo.SumoManagement
{
    public class SumoContainer : MonoBehaviour
    {
        // Singleton pointer
        public static SumoContainer Instance { get; private set; }

        // List of references to hold sumos in the scene.
        public List<GameObject> sumos = new List<GameObject>();

        private void Awake()
        {
            // Set this class as Singleton
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        // Return sumo with the highest score which is winner.
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

                if (sumo.GetComponent<Sumo.Character.Score>().CharacterScore > winnerSumo.GetComponent<Sumo.Character.Score>().CharacterScore)
                {
                    winnerSumo = sumo;
                }
            }
            return winnerSumo;
        }
    }

}
