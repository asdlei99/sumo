using UnityEngine;

public class Push : MonoBehaviour
{
    private bool updateEvent = false;
    private float pushStartTime;
    private float pushDuration = 0.5f;
    private GameObject targetSumo;
    private Vector3 pushDirection;
    private void Update()
    {
        if (updateEvent)
            UpdateEvent();
    }

    public void StartEvent(Collision hit)
    {
        Debug.Log("Pushing...");
        pushStartTime = Timer.Instance.CurrentTime;
        pushDirection = (this.transform.position - hit.transform.position).normalized;
        targetSumo = hit.gameObject;
        GetComponent<CharacterProperties>().isBeingPushed = true;
        GetComponent<CharacterProperties>().lastHitSumo = hit.gameObject;
        updateEvent = true;
    }

    private void UpdateEvent()
    {
        if (pushStartTime + pushDuration < Timer.Instance.CurrentTime)
            ExitEvent();

        // Push target sumo.
        float pushForce = -GetComponent<CharacterProperties>().pushForce / targetSumo.transform.localScale.x;
        targetSumo.GetComponent<CharacterController>().Move(pushForce * pushDirection * Time.deltaTime);
    }

    private void ExitEvent()
    {
        GetComponent<CharacterProperties>().isBeingPushed = false;
        updateEvent = false;
    }

}
