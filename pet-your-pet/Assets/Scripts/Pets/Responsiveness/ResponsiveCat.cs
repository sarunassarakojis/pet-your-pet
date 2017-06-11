using UnityEngine;

public class ResponsiveCat : MonoBehaviour
{
    public int counter { get; private set; }
    public float secondsBetweenDecrements;
    public int initialCount;

    private AudioSource audioSource;

    void Start()
    {
        counter = initialCount;
        InvokeRepeating("DecrementCounter", secondsBetweenDecrements, secondsBetweenDecrements);
        audioSource = GetComponent<AudioSource>();
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
