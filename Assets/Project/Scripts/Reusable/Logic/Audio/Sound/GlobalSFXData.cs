using System.Collections.Generic;
using UnityEngine;

public class GlobalSFXData : AudioData<GlobalSFXData>
{
    [SerializeField] private ClickSFX _clickSound;

    protected override string MutedSaveKey => $"{nameof(GlobalSFXData)}IsMuted";

    protected override IReadOnlyCollection<Audio> Audios => new List<Audio>()
    {
        _clickSound
    };
}