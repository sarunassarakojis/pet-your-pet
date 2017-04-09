using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 movement;
    private Animator animator;
    private Rigidbody playerRigidbody;
    private int floorMask;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal, vertical);
        RotatePlayer(horizontal, vertical);
        AnimatePlayer(horizontal, vertical);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void RotatePlayer(float horizontal, float vertical)
    {
        //float heading = Mathf.Atan2(playerRigidbody.velocity.x, playerRigidbody.velocity.z);
        //Quaternion rotation = Quaternion.Euler(0, heading, 0);

        //playerRigidbody.MoveRotation(rotation);
    }

    void AnimatePlayer(float horizontal, float vertical)
    {
        animator.SetBool("IsWalking", horizontal != 0 || vertical != 0);
    }
}
