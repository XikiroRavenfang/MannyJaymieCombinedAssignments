using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    private PathFollowing pf;
    private Wander w;
    private GameObject player;
    private float timer;

    public float trackTime;
    public float vision;

    void Start()
    {
        pf = GetComponent<PathFollowing>();
        w = GetComponent<Wander>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 playerPos = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        Vector3 rayDir = playerPos - transform.position;
        rayDir = rayDir.normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDir, out hit, vision))
        {
            if (hit.collider.CompareTag("Player"))
            {
                pf.target = player.transform;
                w.enabled = false;
                timer = trackTime;
            }
            else if (pf.target != null && timer <= 0)
            {
                pf.target = null;
                w.enabled = true;
            }
        }
        timer -= Time.deltaTime;
    }
}
