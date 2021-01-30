using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private CharacterProperties characterProperties;
    private CharacterController characterController;
    private bool updateEvent = false;
    private float pushStartTime;
    private float pushDuration = 0.5f;
    private float enemyPushForce;
    private Vector3 pushDirection;

    private void Start()
    {
        characterProperties = GetComponent<CharacterProperties>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (updateEvent)
            UpdateEvent();
    }

    public void StartEvent(ControllerColliderHit hit)
    {
        pushStartTime = Timer.Instance.CurrentTime;
        pushDirection = (this.transform.position - hit.transform.position).normalized;
        enemyPushForce = hit.gameObject.GetComponent<CharacterProperties>().pushForce;
        characterProperties.isBeingPushed = true;
        updateEvent = true;
    }

    private void UpdateEvent()
    {
        if (pushStartTime + pushDuration < Timer.Instance.CurrentTime)
            ExitEvent();
        
        characterController.Move(enemyPushForce * pushDirection * Time.deltaTime);
    }

    private void ExitEvent()
    {
        characterProperties.isBeingPushed = false;
        updateEvent = false;
    }

}
