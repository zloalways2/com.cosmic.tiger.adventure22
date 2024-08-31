using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicData : AudioData<GlobalMusicData>
{
    [SerializeField] private BackgroundLoop _backgroundLoop;

    public static GlobalMusicData Instance { get; private set; }

    protected override string MutedSaveKey => $"{nameof(GlobalMusicData)}IsMuted";

    protected override IReadOnlyCollection<Audio> Audios => new List<Audio>()
    {
        _backgroundLoop
    };
}