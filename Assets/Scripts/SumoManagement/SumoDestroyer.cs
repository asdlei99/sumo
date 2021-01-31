using UnityEngine;

namespace Sumo.SumoManagement
{

    public class SumoDestroyer : MonoBehaviour
    {
        private void OnDestroy()
        {
            GameObject lastPushedSumo = GetComponent<Sumo.Character.Collision.Push>().lastPushedSumo;
            if (lastPushedSumo != null)
            {
                lastPushedSumo.GetComponent<Sumo.Character.Score>().AddScore(1000);
            }

            // Remove sumo from Sumo Container references list.
            SumoContainer.Instance.sumos.Remove(gameObject);
        }
    }
}
