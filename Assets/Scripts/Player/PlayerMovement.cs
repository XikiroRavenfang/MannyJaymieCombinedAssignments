using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float speedMulti = 20f;

    private PlayerStats pStats;
    private Vector3 moveDir = Vector3.zero;
    private Rigidbody rigid;
    // Use this for initialization
    void Awake()
    {
        pStats = GetComponent<PlayerStats>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        moveDir = new Vector3(inputH, 0, inputV);
        moveDir *= speedMulti * pStats.speed * Time.deltaTime;
        rigid.velocity = moveDir;
        if (rigid.velocity.magnitude > pStats.speed)
            rigid.velocity = rigid.velocity.normalized * pStats.speed;

        if (moveDir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(moveDir);
    }
}
