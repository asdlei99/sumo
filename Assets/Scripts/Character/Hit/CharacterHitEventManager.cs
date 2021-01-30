using UnityEngine;

public class CharacterHitEventManager : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Sumo")
            GetComponent<Push>().StartEvent(hit);

        if (hit.gameObject.tag == "Enhancer")
            GetComponent<CollectEnhancer>().StartEvent(hit);
    }
}
