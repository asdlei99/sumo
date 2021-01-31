using UnityEngine;

/**
 *  This class destroys anything collided with deathzone.
 */

namespace Sumo.DeathZone
{
    public class Destroyer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // If sumo is the player character restart game.
            if (other.tag == "Player")
            {
                Sumo.GameStateManagement.GameRestarter.Instance.Restart(false);
                return;
            }

            Destroy(other.gameObject);
        }
    }

}

