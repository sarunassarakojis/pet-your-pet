using UnityEngine;

public class ResponsiveCat : MonoBehaviour
{
    public int counter { get; private set; }
    public float secondsBetweenDecrements;
    public int initialCount;
    public AudioClip[] audioClips;

    private CharacterSoundPlayer petSoundPlayer;

    void Start()
    {
        counter = initialCount;
        InvokeRepeating("DecrementCounter", secondsBetweenDecrements, secondsBetweenDecrements);
        petSoundPlayer = new CharacterSoundPlayer(GetComponent<AudioSource>(), audioClips);
    }

    private void OnMouseDown()
    {
        counter++;

        petSoundPlayer.PlayRandomAudioClip();
    }

    private void DecrementCounter()
    {
        counter--;
    }
}
