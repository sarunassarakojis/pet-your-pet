using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip[] hitAudioClips;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public int currentHealth;

    private CharacterSoundPlayer soundPlayer;
    private bool isDead;
    private bool damaged;

    void Awake()
    {
        currentHealth = startingHealth;
        soundPlayer = new CharacterSoundPlayer(GetComponent<AudioSource>(), hitAudioClips);
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
            damaged = false;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        soundPlayer.PlayRandomAudioClip();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        soundPlayer.PlayAudioClip(deathClip);
    }
}
