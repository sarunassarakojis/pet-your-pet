using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(PetCharacter))]
    public class AICatCharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }
        public PetCharacter character { get; private set; }
        public float distanceWhenToMove = 10f;
        public int friendlinessThreshold = 20;
        public Transform target;

        private ResponsiveCharacter responsiveCharacter;

        private void Start()
        {
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<PetCharacter>();
            responsiveCharacter = GetComponent<ResponsiveCharacter>();

            agent.updateRotation = false;
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
            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }

        private void StayAwayFromTarget()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - target.position);
            Vector3 runTo = transform.position + transform.forward * 10;
            UnityEngine.AI.NavMeshHit hit;

            UnityEngine.AI.NavMesh.SamplePosition(runTo, out hit, distanceWhenToMove, -1);
            agent.SetDestination(hit.position);
            character.Move(agent.desiredVelocity, false, false);
        }

        private void KeepCloseWithTarget()
        {
            agent.SetDestination(target.position);
            character.Move(agent.desiredVelocity, false, false);
        }
    }
}
