using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AICatControl : MonoBehaviour
{
    public float distanceWhenToMove = 10f;
    public int friendlinessThreshold = 20;
    public Transform target;

    private NavMeshAgent agent;
    private ResponsiveCat responsiveCharacter;
    private Animator animator;

    private void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        responsiveCharacter = GetComponent<ResponsiveCat>();
        animator = GetComponent<Animator>();

        agent.updateRotation = true;
        agent.updatePosition = true;
    }

    private void Update()
    {
        float remainingDistance = Vector3.Magnitude(target.position - transform.position);
        bool closeEnough = remainingDistance < distanceWhenToMove;
        bool isFriendly = responsiveCharacter.counter >= friendlinessThreshold;

        if (remainingDistance > agent.stoppingDistance && closeEnough && isFriendly)
        {
            KeepCloseWithTarget();
        }
        else if (closeEnough && !isFriendly)
        {
            StayAwayFromTarget();
        }

        UpdateAnimator(agent.desiredVelocity);
    }

    private void StayAwayFromTarget()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - target.position);
        Vector3 runTo = transform.position + transform.forward * 10;
        NavMeshHit hit;

        NavMesh.SamplePosition(runTo, out hit, distanceWhenToMove, -1);
        agent.SetDestination(hit.position);
    }

    private void KeepCloseWithTarget()
    {
        agent.SetDestination(target.position);
    }

    void UpdateAnimator(Vector3 move)
    {
        animator.SetBool("IsWalking", move.x != 0 || move.z != 0);
    }
}
