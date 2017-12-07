using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PathFollowing : SteeringBehaviour
{
    public Transform target;
    public float nodeRadius = .1f;
    public float targetRadius = 3f;

    private int currentNode = 0;
    private bool isAtTarget = false;
    private NavMeshAgent nav;
    private NavMeshPath path;

    void Start()
    {
        path = new NavMeshPath();
        nav = GetComponent<NavMeshAgent>();
    }

    Vector3 Seek(Vector3 target)
    {
        Vector3 force = Vector3.zero;
        Vector3 desiredForce = target - transform.position;
        float distance = isAtTarget ? targetRadius : nodeRadius;

        if (desiredForce.magnitude > distance)
        {
            desiredForce = desiredForce.normalized * weighting;
            force = desiredForce - owner.velocity;
        }

        return force;
    }

    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        if (!target)
            return force;

        if (nav.CalculatePath(target.position, path))
        {
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                Vector3[] corners = path.corners;
                if (corners.Length > 0)
                {
                    int lastIndex = corners.Length - 1;
                    if (currentNode >= corners.Length)
                        currentNode = lastIndex;

                    Vector3 currentPos = corners[currentNode];
                    float distance = Vector3.Distance(transform.position, currentPos);

                    if (distance <= nodeRadius)
                        currentNode++;

                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    isAtTarget = distanceToTarget <= targetRadius;

                    force = Seek(currentPos);
                }
            }
        }

        return force;
    }
}