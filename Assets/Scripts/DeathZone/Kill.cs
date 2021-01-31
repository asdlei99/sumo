using UnityEngine;

namespace Sumo.DeathZone
{
    public class Kill : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            // If sumo is the player character restart game.
            if (other.tag == "Player")
            {
                GameRestarter.Instance.Restart(false);
                return;
            }

            Destroy(other.gameObject);
        }
    }

}

