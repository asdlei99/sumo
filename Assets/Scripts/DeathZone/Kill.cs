using UnityEngine;

namespace Sumo.DeathZone
{
    public class Kill : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Sumos.Instance.SumosInGame.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }

}

