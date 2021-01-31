using UnityEngine;
using TMPro;

namespace Sumo.UI
{
    public class SumosUI : MonoBehaviour
    {
        // Singleton pointer
        public static SumosUI Instance { get; private set; }

        [SerializeField]
        TextMeshProUGUI sumosText;

        private void Awake()
        {
            // Set this class as Singleton
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        // Update is called once per frame
        void Update()
        {
            sumosText.text = Sumo.SumoManagement.SumoContainer.Instance.sumos.Count.ToString();
            if (Sumo.SumoManagement.SumoContainer.Instance.sumos.Count == 1)
                Sumo.GameStateManagement.GameRestarter.Instance.Restart(true);
        }
    }
}
