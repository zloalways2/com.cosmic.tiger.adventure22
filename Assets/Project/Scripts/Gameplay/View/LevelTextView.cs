public class LevelTextView : TextView<int>
{
    private void Awake()
    {
        var level = Level.GetLevel();
        UpdateText(level);
    }
}