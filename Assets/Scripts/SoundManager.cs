using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
       instance = this;
       source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
    public void SetPitch(float pitch)
    {
        source.pitch = pitch;
    }

    public void ResetPitch()
    {
        source.pitch = 1.0f; // Default pitch
    }
}
