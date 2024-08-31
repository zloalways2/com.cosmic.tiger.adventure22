using System;

public static class ClickSFXPlayRequest
{
    public static event Action Sent;

    public static void Send()
    {
        Sent?.Invoke();
    }
}