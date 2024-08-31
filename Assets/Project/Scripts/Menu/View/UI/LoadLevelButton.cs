using UnityEngine;

public class LoadLevelButton : ButtonListener
{
    private const string LevelSceneName = "Gameplay";

    [Range(Level.MinValue, Level.MaxValue)]
    [SerializeField] private int _level = Level.MinValue;

    protected override void Listen()
    {
        if (!Level.TrySetLevel(_level)) return;

        SceneLoad.Load(LevelSceneName);
    }
}