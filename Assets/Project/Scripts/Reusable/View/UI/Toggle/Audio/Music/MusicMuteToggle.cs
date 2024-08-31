public class MusicMuteToggle : ToggleListener
{
    protected override void HandleSubscribed()
    {
        Toggle.SetIsOnWithoutNotify(!GlobalMusicData.StaticInstance.IsMuted);
    }

    protected override void HandleEnabled()
    {
        GlobalMusicData.StaticInstance.UnMute();
    }

    protected override void HandleDisabled()
    {
        GlobalMusicData.StaticInstance.Mute();
    }
}