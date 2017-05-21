using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class FreeRoamScript : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private PetCharacter petCharacter;
    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;

    void Start()
    {
        petCharacter = GetComponent<PetCharacter>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        timer = wanderTimer;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            timer = 0;

            agent.SetDestination(RandomNavSphere(transform.position, wanderRadius, -1));
            petCharacter.Move(agent.desiredVelocity, false, false);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist + origin;
        UnityEngine.AI.NavMeshHit navHit;

        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
