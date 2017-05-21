using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(CatCharacter))]
    public class AICatCharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }
        public CatCharacter character { get; private set; }
        public float distanceWhenToMove = 10f;
        public Transform target;

        private void Start()
        {
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<CatCharacter>();

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

        private void MoveRandomlyWithinStoppingDistance()
        {
            Vector3 randomDirection = Random.insideUnitSphere * agent.stoppingDistance;
            UnityEngine.AI.NavMeshHit meshHit;

            randomDirection += transform.position;
            UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out meshHit, agent.stoppingDistance, 1);

            Debug.Log("Moving from: " + transform.position + " to: " + meshHit.position);

            agent.SetDestination(meshHit.position);
            character.Move(agent.desiredVelocity, false, false);
        }
    }
}
