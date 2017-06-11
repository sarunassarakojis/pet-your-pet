using UnityEngine;
using UnityEngine.AI;

class AIControlDisabler
{
    private NavMeshAgent[] bearAgents;
    private PlayerUserControl playerControl;

    public AIControlDisabler()
    {
        GameObject[] bears = GameObject.FindGameObjectsWithTag("Bear");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerUserControl>();
        bearAgents = new NavMeshAgent[bears.Length];

        for (int i = 0; i < bears.Length; i++)
        {
            bearAgents[i] = bears[i].GetComponent<NavMeshAgent>();
        }
    }

    public void DisablePlayerControl()
    {
        playerControl.enabled = false;
    }

    public void DisableAIBearControl()
    {
        for (int i = 0; i < bearAgents.Length; i++)
        {
            bearAgents[i].enabled = false;
        }
    }
}
