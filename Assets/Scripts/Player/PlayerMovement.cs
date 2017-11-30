using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerActions))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5f;
    public float speedMulti = 20f;

    private PlayerStats pStats;
    private PlayerActions pActions;
    private Vector3 moveDir = Vector3.zero;
    private Rigidbody rigid;
    // Use this for initialization
    void Awake()
    {
        pActions = GetComponent<PlayerActions>();
        pStats = GetComponent<PlayerStats>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pActions.inAction)
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
