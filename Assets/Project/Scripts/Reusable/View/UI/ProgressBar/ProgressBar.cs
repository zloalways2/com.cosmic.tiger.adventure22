using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    protected abstract event Action<float> RefreshEvent;
    protected abstract float MaxValue { get; }
    protected abstract bool Interactable { get; }

    private void Awake()
    {
        _slider.interactable = Interactable;
        _slider.minValue = default;
        _slider.maxValue = MaxValue;
    }

    private void Refresh(float value)
    {
        _slider.value = value;
    }

    private void OnEnable()
    {
        RefreshEvent += Refresh;
    }

    private void OnDisable()
    {
        RefreshEvent -= Refresh;
    }
}