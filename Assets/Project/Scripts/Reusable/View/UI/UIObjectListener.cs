using UnityEngine;

public abstract class UIObjectListener : MonoBehaviour
{
    protected abstract void Subscribe();
    protected virtual void HandleAwake() { }
    protected virtual void Listen() { }

    private void Awake()
    {
        HandleAwake();
    }

    private void Start()
    {
        Subscribe();
    }
}