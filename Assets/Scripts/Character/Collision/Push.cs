using UnityEngine;

/**
 * This class is responsible for character's push.
 */

namespace Sumo.Character.Collision
{
    public class Push : MonoBehaviour
    {
        #region Properties
        private bool updateEvent = false;
        private float pushStartTime;
        private float pushDuration = 0.5f;
        private GameObject targetSumo;
        private Vector3 pushDirection;

        // Flag to check if character is being pushed at the moment.
        public bool isBeingPushed = false;

        // Reference to last pushed sumo.
        public GameObject lastPushedSumo = null;

        // Current push force of the character
        public float pushForce = 0f;

        // Max push force that character can have by collecting enhancers.
        public float maxPushForce = 0f;
        #endregion

        private void Update()
        {
            if (updateEvent)
                UpdateEvent();
        }

        public void StartEvent(UnityEngine.Collision hit)
        {
            pushStartTime = Sumo.TimeManagement.Timer.Instance.CurrentTime;
            pushDirection = (this.transform.position - hit.transform.position).normalized;
            targetSumo = hit.gameObject;
            GetComponent<Push>().isBeingPushed = true;
            GetComponent<Push>().lastPushedSumo = hit.gameObject;
            updateEvent = true;
        }

        private void UpdateEvent()
        {
            if (pushStartTime + pushDuration < Sumo.TimeManagement.Timer.Instance.CurrentTime)
                ExitEvent();

            // Push target sumo.
            float pushForceScaleRatio = -pushForce / targetSumo.transform.localScale.x;
            targetSumo.GetComponent<CharacterController>().Move(pushForceScaleRatio * pushDirection * Time.deltaTime);
        }

        private void ExitEvent()
        {
            GetComponent<Push>().isBeingPushed = false;
            updateEvent = false;
        }

    }
}