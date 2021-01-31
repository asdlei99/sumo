using UnityEngine;

public class CharacterHitEventManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision hit)
    {
        Debug.Log("Collision Hit");

        if (hit.gameObject.tag == "Sumo" || hit.gameObject.tag == "Player")
            GetComponent<Push>().StartEvent(hit);

        if (hit.gameObject.tag == "Enhancer")
            GetComponent<CollectEnhancer>().StartEvent(hit);
    }

}
