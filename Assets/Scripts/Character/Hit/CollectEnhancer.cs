using UnityEngine;

public class CollectEnhancer : MonoBehaviour
{
    CharacterProperties characterProperties;

    private void Start()
    {
        characterProperties = GetComponent<CharacterProperties>();
    }

    public void StartEvent(Collision hit)
    {
        Debug.Log("Picking Enhancer...");

        

        // 
        hit.gameObject.GetComponent<EnhancerDestroyer>().SetPicker(transform.gameObject);

        // Destroy pickable
        Destroy(hit.gameObject);
    }
}
