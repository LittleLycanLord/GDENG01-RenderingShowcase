using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private List<Sound> sounds = new List<Sound>();

    //! ╔═══════════════════╗
    //! ║ SINGLETON CONTENT ║
    //! ╚═══════════════════╝
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    //! - - - - - - - - - - -

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.loop = sound.loop;
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.volume = sound.volume;
        }
    }

    public void Play(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound with name [" + name + "] not found.");
            return;
        }
        sound.audioSource.Play();
    }

    public void Play(string name, float fadeIn)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound with name [" + name + "] not found.");
            return;
        }
        sound.audioSource.Play();
        StartCoroutine(FadeIn(sound, fadeIn));
    }

    public void Stop(string name)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound with name [" + name + "] not found.");
            return;
        }
        sound.audioSource.Stop();
    }

    public void Stop(string name, float fadeOut)
    {
        Sound sound = sounds.Find(sound => sound.name == name);
        if (sound == null)
        {
            Debug.LogWarning("Sound with name [" + name + "] not found.");
            return;
        }
        StartCoroutine(FadeOut(sound, fadeOut));
    }

    public void StopAll()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource.Stop();
        }
    }

    public void StopAll(float fadeOut)
    {
        foreach (Sound sound in sounds)
        {
            StartCoroutine(FadeOut(sound, fadeOut));
        }
    }

    IEnumerator FadeIn(Sound sound, float fadeInAmount)
    {
        float timeElapsed = 0;

        while (sound.volume < 1)
        {
            sound.volume = Mathf.Lerp(0, 1, timeElapsed / fadeInAmount);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOut(Sound sound, float fadeOutAmount)
    {
        float timeElapsed = 0;

        if (sound.volume <= 0)
        {
            sound.audioSource.Stop();
        }
        else
        {
            while (sound.volume > 0)
            {
                sound.volume = Mathf.Lerp(1, 0, timeElapsed / fadeOutAmount);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
