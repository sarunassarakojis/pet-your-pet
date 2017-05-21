using UnityEngine;

public class FreeRoamScript : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private float timer;

    void Start()
    {
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
