public class ButtonClickSFX : ButtonListener
{
    protected override void Listen()
    {
        ClickSFXPlayRequest.Send();
    }
}