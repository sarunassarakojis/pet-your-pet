using UnityEngine;
using UnityEngine.AI;

public class AIBearControl : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navAgent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navAgent.SetDestination(player.position);
    }
}
