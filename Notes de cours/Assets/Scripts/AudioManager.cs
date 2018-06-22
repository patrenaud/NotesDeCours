﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : DontDestroyOnLoad
{
    // Static = On peut y accéder de partout et tout le monde
    private static AudioManager m_Instance;
    public static AudioManager Instance
    {
        // On fait un get public pour que les autres classes puissent accéder au Singleton sans pouvoir l'assigner (set)
        get
        {
            return m_Instance;
        }
    }

    [SerializeField]
    private SFXAudio m_SFXAudioPrefab;

    [SerializeField]
    private AudioSource m_AudioSourceMusic;

    [SerializeField]
    private AudioClip m_Music1;
    [SerializeField]
    private AudioClip m_Music2;

    protected override void Awake()
    {
        // Ici, on s'assure qu'il n'y ait qu'un seul
        if (m_Instance != null)
        {
            Destroy(gameObject); // On détruit le 2e
        }
        else
        {
            m_Instance = this; // Celui-ci est roi de la montagne (On l'assigne au static)
        }
        base.Awake(); // On doit appeler le parent pour que le DontDestroy se fasse.
    }

    private IEnumerator FadeOutFadeInMusic(float i_Duration, AudioClip i_NextClip) // i_Duration est le temps que le volume se rendre au maximum
    {
        if (i_Duration <= 0) // Ici on instaure un WARNING si la duration est trop faible 
        {
            Debug.LogError("Error Duration <= 0 so don't do it you piece of shit, ASK PAT IF YOU SEE THIS"); // Laisse des traces en équipes pour débug
            yield break; // Sort de l'énumérateur.
        }
        while (m_AudioSourceMusic.volume > 0f)
        {
            m_AudioSourceMusic.volume -= Time.deltaTime / i_Duration;
            yield return null;
        }

        m_AudioSourceMusic.clip = i_NextClip;
        m_AudioSourceMusic.Play();

        while (m_AudioSourceMusic.volume < 1f)
        {
            m_AudioSourceMusic.volume += Time.deltaTime / i_Duration;
        }
    }

    public void SwitchMusic(float i_Duration)
    {
        AudioClip nextClip = m_AudioSourceMusic.clip == m_Music1 ? m_Music2 : m_Music1;
        StartCoroutine(FadeOutFadeInMusic(i_Duration, nextClip));
    }

    public void PlaySFX(AudioClip i_Clip, Vector3 i_Position) // au lieu du vector, un transform et un bool. Le son se fait sur le character et bool le suit ou pas
    {
        SFXAudio audio = Instantiate(m_SFXAudioPrefab, i_Position, Quaternion.identity);
        audio.Setup(i_Clip);
        audio.Play();
        Debug.Log("Play");
    }

}