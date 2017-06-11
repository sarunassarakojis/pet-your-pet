using UnityEngine;
using UnityEngine.AI;

public class AIBearControl : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navAgent;
    private PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (navAgent.enabled && playerHealth.currentHealth > 0)
        {
            navAgent.SetDestination(player.position);
        }
    }
}
