using System.Collections.Generic;
using UnityEngine;

public abstract class AudioData<T> : MonoBehaviour where T : AudioData<T>
{
    private const int EnabledValue = 1;
    private const int DisabledValue = 0;

    public static AudioData<T> StaticInstance;
    public bool IsMuted => PlayerPrefs.GetInt(MutedSaveKey, DisabledValue) == EnabledValue;

    protected abstract IReadOnlyCollection<Audio> Audios { get; }
    protected abstract string MutedSaveKey { get; }

    public void Mute()
    {
        var audios = Audios;

        foreach (var audio in audios)
        {
            audio.Mute();
        }

        PlayerPrefs.SetInt(MutedSaveKey, EnabledValue);
    }

    public void UnMute()
    {
        var audios = Audios;

        foreach (var audio in audios)
        {
            audio.UnMute();
        }

        PlayerPrefs.SetInt(MutedSaveKey, DisabledValue);
    }

    private void Awake()
    {
        var audios = FindObjectsOfType<AudioData<T>>();

        foreach (var music in audios)
        {
            if (music == this)
            {
                continue;
            }

            Destroy(music.gameObject);
        }

        DontDestroyOnLoad(gameObject);
        StaticInstance = this;

        if (IsMuted) Mute();
        else UnMute();
    }
}