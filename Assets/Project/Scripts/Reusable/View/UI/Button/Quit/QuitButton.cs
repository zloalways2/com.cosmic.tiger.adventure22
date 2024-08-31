using UnityEngine;

public class QuitButton : ButtonListener
{
    protected override void Listen()
    {
        Application.Quit();
    }
}