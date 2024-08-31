using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonListener : UIObjectListener
{
    protected virtual void HandleSubscribed() { }

    protected override void Subscribe()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(Listen);

        HandleSubscribed();
    }
}