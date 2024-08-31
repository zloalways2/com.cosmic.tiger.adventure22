using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class Audio : MonoBehaviour
{
    private AudioSource _source;

    public bool IsInitialized { get; private set; }

    protected virtual event Action PlayEvent { add { } remove { } }

    public void Play()
    {
        TryInitialize();
        _source.Play();
    }

    public void Mute()
    {
        TryInitialize();
        _source.mute = true;
    }

    public void UnMute()
    {
        TryInitialize();
        _source.mute = false;
    }

    private bool TryInitialize()
    {
        if (IsInitialized) return false;

        _source = GetComponent<AudioSource>();

        PlayEvent += Play;

        return IsInitialized = true;
    }

    private void OnDestroy()
    {
        PlayEvent -= Play;
    }
}