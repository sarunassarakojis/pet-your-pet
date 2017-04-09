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

    }

    void AnimatePlayer(float horizontal, float vertical)
    {
        animator.SetBool("IsWalking", horizontal != 0 || vertical != 0);
    }
}
