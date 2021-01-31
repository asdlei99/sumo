using UnityEngine;

/**
 * This class performs push or enhancer collection operations when character has collision.
 */
namespace Sumo.Character.Collision
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnCollisionEnter(UnityEngine.Collision hit)
        {
            // Push hit gameobject if it is "Sumo" or "Player"
            if (hit.gameObject.tag == "Sumo" || hit.gameObject.tag == "Player")
                GetComponent<Sumo.Character.Collision.Push>().StartEvent(hit);

            // Collect enhancer if collided object is "Enhancer"
            if (hit.gameObject.tag == "Enhancer")
                GetComponent<Sumo.Character.Collision.EnhancerCollector>().StartEvent(hit);
        }

    }
}

