using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip cursor;
    public AudioClip drop;
    public AudioClip control;
    public AudioClip lineClear;
    public AudioClip gameOver;

    private AudioSource audioSource;
    public bool isMute;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip)
    {
        if (isMute) return;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PlayCursor()
    {
        PlayAudio(cursor);
    }

    public void PlayDrop()
    {
        PlayAudio(drop);

    }

    public void PlayControl()
    {
        PlayAudio(control);

    }

    public void PlayLineClear()
    {
        PlayAudio(lineClear);

    }




}
