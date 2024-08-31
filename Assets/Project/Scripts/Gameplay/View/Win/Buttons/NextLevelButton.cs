public class NextLevelButton : ButtonListener
{
    protected override void HandleSubscribed()
    {
        if (Level.IsLastLevel) Destroy(gameObject);
    }

    protected override void Listen()
    {
        if (!Level.TrySetNextLevel()) return;

        SceneLoad.Restart();
    }
}