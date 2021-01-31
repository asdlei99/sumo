using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        SetRotation();
    }

    private Vector3 GetTargetDirection()
    {
        GameObject target = null;

        foreach (GameObject sumo in SumoContainer.Instance.sumos)
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

        foreach(GameObject enhancer in EnhancerContainer.Instance.enchancers)
        {
            if (enhancer == null)
                continue;

            float distance = Vector3.Distance(transform.position, enhancer.transform.position);
            float currrentTargetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < currrentTargetDistance)
                target = enhancer;
        }

        Vector3 targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0;
        return targetDirection;
    }

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
