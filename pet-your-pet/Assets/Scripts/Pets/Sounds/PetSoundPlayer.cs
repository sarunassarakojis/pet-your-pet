using UnityEngine;

class PetSoundPlayer
{
    private AudioSource audioSource;
    private AudioClip[] audioClips;
    private System.Random random;

    public PetSoundPlayer(AudioSource audioSource, AudioClip[] audioClips)
    {
        this.audioSource = audioSource;
        this.audioClips = audioClips;
        this.random = new System.Random();
    }

    public void PlayRandomAudioClip()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = audioClips[random.Next(audioClips.Length)];

            audioSource.Play();
        }
    }

}
