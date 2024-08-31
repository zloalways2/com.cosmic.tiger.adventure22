using System;

public sealed class ClickSFX : SFX
{
    protected override event Action PlayEvent
    {
        add
        {
            ClickSFXPlayRequest.Sent += value;
        }
        remove
        {
            ClickSFXPlayRequest.Sent -= value;
        }
    }
}