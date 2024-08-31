public class ToggleClickSFX : ToggleListener
{
    protected override void Listen()
    {
        ClickSFXPlayRequest.Send();
    }
}