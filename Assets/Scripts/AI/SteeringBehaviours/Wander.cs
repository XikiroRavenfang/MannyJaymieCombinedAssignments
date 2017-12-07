using UnityEngine;
using System.Collections;



public class Wander : SteeringBehaviour
{
    public float offset = 1.0f;
    public float radius = 1.0f;
    public float jitter = 0.2f;

    private Vector3 targetDir;
    private Vector3 randomDir;

    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        float randX = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
        float randZ = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);

        randomDir = new Vector3(randX, 0, randZ);
        randomDir = randomDir.normalized;
        randomDir *= jitter;

        targetDir += randomDir;
        targetDir = targetDir.normalized;
        targetDir *= radius;

        Vector3 seekPos = transform.position + targetDir;
        seekPos += transform.forward.normalized * offset;

        Vector3 direction = seekPos - transform.position;
        if (direction.magnitude > 0)
        {
            Vector3 desiredForce = direction.normalized * weighting;
            force = desiredForce - owner.velocity;
        }

        return force;
    }
}
