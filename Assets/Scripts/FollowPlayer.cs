using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        float posX = pos.x;
        float posZ = pos.z;
        transform.position = new Vector3(posX, 0, posZ);
    }
}
