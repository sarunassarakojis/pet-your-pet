using UnityEngine;

public class PetAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public AudioClip[] audioClips;

    private GameObject player;
    private PlayerHealth playerHealth;
    private bool playerInRange;
    private float timer;
    private PetSoundPlayer petSoundPlayer;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        petSoundPlayer = new PetSoundPlayer(GetComponent<AudioSource>(), audioClips);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
    }

    void Attack()
    {
        timer = 0f;


        if (playerHealth.currentHealth > 0)
        {
            petSoundPlayer.PlayRandomAudioClip();
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
