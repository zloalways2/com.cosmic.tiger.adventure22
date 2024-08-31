using System;

public class SceneLoadingBar : ProgressBar
{
    protected override float MaxValue => 1f;
    protected override bool Interactable => false;

    protected override event Action<float> RefreshEvent
    {
        add => SceneLoad.ProgressUpdated += value;
        remove => SceneLoad.ProgressUpdated -= value;
    }
}