using UnityEngine;

public class EnhancerDestroyer: MonoBehaviour
{

    // Reference to sumo that picks this enhance
    private GameObject picker = null;

    private void OnDestroy()
    {
        if (picker == null)
        {
            Debug.Log("Picker is not set!");
            return;
        }

        // Remove pickable from pickables list.
        EnhancerContainer.Instance.enchancers.Remove(gameObject);

        CharacterProperties characterProperties = picker.GetComponent<CharacterProperties>();

        // Spawn new pickable in random position.
        EnhancerSpawner.Instance.Spawn();

        // Scale character up by 10% if it is now reached it's max scale.
        if (picker.transform.localScale.x < characterProperties.maxScale)
            picker.transform.localScale += transform.localScale * 0.1f;

        // Increase push modifier by 10% if it is now reached it's max push force.
        if (characterProperties.pushForce < characterProperties.maxPushForce)
            characterProperties.pushForce += characterProperties.pushForce * 0.1f;

        // Add score to character if it is main player.
        picker.GetComponent<SumoScore>().AddScore(100);
    }

    public void SetPicker(GameObject newPicker)
    {
        if(picker == null)
            picker = newPicker;
    }
}
