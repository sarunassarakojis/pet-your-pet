using UnityEngine;

public class ResponsiveCharacter : MonoBehaviour
{
    public int counter { get; private set; }
    public float secondsBetweenDecrements;
    public int initialCount;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        counter = initialCount;
        InvokeRepeating("DecrementCounter", secondsBetweenDecrements, secondsBetweenDecrements);
    }

    private void OnMouseDown()
    {
        counter++;

        PlayAudio();
    }

    private void DecrementCounter()
    {
        counter--;
    }

    private void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
