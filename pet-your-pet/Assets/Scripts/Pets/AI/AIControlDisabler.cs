using UnityEngine;
using UnityEngine.AI;

class AIControlDisabler
{
    private NavMeshAgent[] bearAgents;
    private PlayerUserControl playerControl;
    private PlayerCharacter playerCharacter;

    public AIControlDisabler()
    {
        GameObject[] bears = GameObject.FindGameObjectsWithTag("Bear");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<PlayerUserControl>();
        playerCharacter = player.GetComponent<PlayerCharacter>();
        bearAgents = new NavMeshAgent[bears.Length];

        for (int i = 0; i < bears.Length; i++)
        {
            bearAgents[i] = bears[i].GetComponent<NavMeshAgent>();
        }
    }

    public void DisablePlayerControl()
    {
        playerControl.enabled = false;
        playerCharacter.enabled = false;
    }

    public void DisableAIBearControl()
    {
        for (int i = 0; i < bearAgents.Length; i++)
        {
            bearAgents[i].enabled = false;
        }
    }
}
