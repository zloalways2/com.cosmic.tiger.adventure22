using UnityEngine;

public class PolicyAcceptView : MonoBehaviour
{
    private const string ShowSaveKey = "PolicyAccepted";

    [SerializeField] private GameObject _view;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(ShowSaveKey))
        {
            _view.SetActive(true);
        }
        else
        {
            Destroy(_view);
        }
    }

    public void Hide()
    {
        Destroy(_view);
        PlayerPrefs.SetInt(ShowSaveKey, default);
    }
}