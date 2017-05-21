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
        public Transform target;

        private void Start()
        {
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<PetCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        private void Update()
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
            }

            float remainingDistance = agent.remainingDistance;

            if (remainingDistance > agent.stoppingDistance && remainingDistance < distanceWhenToMove)
            {
                agent.Resume();
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                agent.Stop();
                character.Move(Vector3.zero, false, false);
            }
        }
    }
}
