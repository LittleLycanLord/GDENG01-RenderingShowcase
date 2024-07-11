using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Sound", menuName = "Audio/Sound")]
public class Sound : ScriptableObject
{
    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip audioClip;
    public bool loop;

    [Range(0.1f, 2.0f)]
    public float pitch = 1.0f;

    [Range(0.1f, 3.0f)]
    public float volume = 1.0f;
}
