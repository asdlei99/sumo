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

        foreach (GameObject sumo in Sumos.Instance.SumosInGame)
        {
            if (sumo.transform == transform)
                continue;

            if (target == null)
                target = sumo;

            float distance = Vector3.Distance(transform.position, sumo.transform.position);
            float currrentTargetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < currrentTargetDistance)
                target = sumo;
        }

        foreach(GameObject pickable in Pickables.Instance.pickablesInGame)
        {
            float distance = Vector3.Distance(transform.position, pickable.transform.position);
            float currrentTargetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < currrentTargetDistance)
                target = pickable;
        }

        return target.transform.position - transform.position;
    }

    private void SetRotation()
    {
        // Get direction to closest sumo.
        Vector3 targetDirection = GetTargetDirection();

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
