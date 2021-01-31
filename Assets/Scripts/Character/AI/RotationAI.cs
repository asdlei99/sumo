using UnityEngine;

/**
 *  This class is responsible for rotation of AI Characters.
 */

namespace Sumo.Character.AI
{
    public class RotationAI : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            // Set rotation of the character.
            SetRotation();
        }

        /**
         * Checks each object in the scene and return direction to closests object.
         */
        private Vector3 GetTargetDirection()
        {
            GameObject target = null;

            /* Search each character in the scene. And check if it closer than current target.*/
            foreach (GameObject sumo in Sumo.SumoManagement.SumoContainer.Instance.sumos)
            {
                if (sumo == null)
                    continue;

                if (sumo.transform == transform)
                    continue;

                if (target == null)
                    target = sumo;

                float distance = Vector3.Distance(transform.position, sumo.transform.position);
                float currrentTargetDistance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < currrentTargetDistance)
                    target = sumo;
            }

            /* Search each enhancer in the scene. And check if it closer than current target.*/
            foreach (GameObject enhancer in Sumo.EnhancerManagement.EnhancerContainer.Instance.enchancers)
            {
                if (enhancer == null)
                    continue;

                float distance = Vector3.Distance(transform.position, enhancer.transform.position);
                float currrentTargetDistance = Vector3.Distance(transform.position, target.transform.position);
                if (distance < currrentTargetDistance)
                    target = enhancer;
            }

            // Calculate target direction and return it.
            Vector3 targetDirection = target.transform.position - transform.position;
            targetDirection.y = 0;
            return targetDirection;
        }

        // Sets rotation to target rotation.
        private void SetRotation()
        {
            // Get direction to closest sumo.
            Vector3 targetDirection = GetTargetDirection();

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 10 * Time.deltaTime, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

}