using UnityEngine;

public class CollectEnhancer : MonoBehaviour
{
    CharacterProperties characterProperties;

    private void Start()
    {
        characterProperties = GetComponent<CharacterProperties>();
    }

    public void StartEvent(ControllerColliderHit hit)
    {
        // Remove pickable from pickables list.
        Pickables.Instance.pickablesInGame.Remove(hit.gameObject);

        // Destroy pickable
        Destroy(hit.gameObject);

        // Spawn new pickable in random position.
        PickableSpawner.Instance.Spawn();

        // Scale character up by 10% if it is now reached it's max scale.
        if (transform.localScale.x < characterProperties.maxScale)
            transform.localScale += transform.localScale * 0.1f;

        // Increase push modifier by 50% if it is now reached it's max push force.
        if (characterProperties.pushForce < characterProperties.maxPushForce)
            characterProperties.pushForce += characterProperties.pushForce * 0.5f;
    }
}
