using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private CharacterController characterController;

    private bool isPushed = false;
    public bool IsPushed { get { return isPushed; } }

    Vector3 pushDirection = Vector3.zero;
    private float pushStartTime = 0f;
    private float pushDuration = .5f;

    private float pushForce = 5f;
    public float PushModifier { get { return pushForce; } }

    private float enemyPushModifier = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Get character controller component and assign reference to it.
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (isPushed)
        {
            if (pushStartTime + pushDuration < Timer.Instance.CurrentTime) { 
                Debug.Log("Push ended");
                isPushed = false;
            }

            characterController.Move(enemyPushModifier * pushDirection * Time.deltaTime);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Sumo")
        {
            
            return;
        }

        if (hit.gameObject.tag == "Pickable")
            OnPickableHit(hit);
    }


    Vector3 maxScale = new Vector3(2.5f, 2.5f, 2.5f);
    float maxPushForce; 
    private void OnPickableHit(ControllerColliderHit hit)
    {
        // Remove pickable from pickables list.
        Pickables.Instance.pickablesInGame.Remove(hit.gameObject);
        
        // Destroy pickable
        Destroy(hit.gameObject);
        
        // Spawn new pickable in random position.
        PickableSpawner.Instance.Spawn();

        // Scale character up by 10% if it is now reached it's max scale.
        if(transform.localScale.magnitude < maxScale.magnitude)
            transform.localScale += transform.localScale * 0.1f;

        // Increase push modifier by 50% if it is now reached it's max push force.
        if (pushForce < maxPushForce)
            pushForce += pushForce * 0.5f;
    }
}
