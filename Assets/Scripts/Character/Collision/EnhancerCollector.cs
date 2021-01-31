using UnityEngine;

/**
 * This class is responsible for character's enhancer collection.
 */

namespace Sumo.Character.Collision
{
    public class EnhancerCollector : MonoBehaviour
    {
        public void StartEvent(UnityEngine.Collision hit)
        {
            // Set picker for this enhancer
            hit.gameObject.GetComponent<EnhancerManagement.EnhancerDestroyer>().SetPicker(transform.gameObject);

            // Destroy pickable
            Destroy(hit.gameObject);
        }
    }
}


