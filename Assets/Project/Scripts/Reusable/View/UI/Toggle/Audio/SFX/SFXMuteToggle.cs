public class SFXMuteToggle : ToggleListener
{
    protected override void HandleSubscribed()
    {
        Toggle.SetIsOnWithoutNotify(!GlobalSFXData.StaticInstance.IsMuted);
    }

    protected override void HandleEnabled()
    {
        GlobalSFXData.StaticInstance.UnMute();
    }

    protected override void HandleDisabled()
    {
        GlobalSFXData.StaticInstance.Mute();
    }
}