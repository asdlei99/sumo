using UnityEngine;

public class SumoDestroyer : MonoBehaviour
{
    private void OnDestroy()
    {
        // Remove sumo from Sumo Container references list.
        SumoContainer.Instance.sumos.Remove(gameObject);
    }
}
