using UnityEngine;

class CharacterSoundPlayer
{
    private AudioSource audioSource;
    private AudioClip[] audioClips;
    private System.Random random;

    public CharacterSoundPlayer(AudioSource audioSource, AudioClip[] audioClips)
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

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;

        audioSource.Play();
    }

}
