using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemIconView : MonoBehaviour
{
    public event Action Initialized;

    [SerializeField] [Min(0.1f)] private float _animationDuration = 1f;
    [SerializeField] private AnimationCurve _ease;

    private Image _icon;
    private PureAnimation _animation;
    private Vector3 _defaultSize;

    public bool AnimationIsPlaying { get; private set; }
    public string IconName => _icon.sprite.name;

    private void Start()
    {
        _icon = GetComponent<Image>();

        _animation = new PureAnimation(this);

        var sprite = ItemRepository.GetRandomIcon();

        _icon.sprite = sprite;
        _icon.raycastTarget = false;

        _defaultSize = transform.localScale;
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);

        Initialized?.Invoke();
    }

    public void ForceHide()
    {
        StopAllCoroutines();
        AnimationIsPlaying = false;
        TryHide();
    }

    public bool TryShow()
    {
        return TryShow(null);
    }

    public bool TryShow(Action callback)
    {
        if (AnimationIsPlaying) return false;

        gameObject.SetActive(true);
        AnimationIsPlaying = true;

        _animation.Play(_animationDuration, (progress) =>
        {
            transform.localScale = _defaultSize * _ease.Evaluate(progress);
        }, () =>
        {
            AnimationIsPlaying = false;
            callback?.Invoke();
        });

        return true;
    }

    public bool TryHide()
    {
        return TryHide(null);
    }

    public bool TryHide(Action callback)
    {
        if (AnimationIsPlaying) return false;

        AnimationIsPlaying = true;

        _animation.Play(_animationDuration, (progress) =>
        {
            transform.localScale = _defaultSize * _ease.Evaluate(1f - progress);
        }, () =>
        {
            gameObject.SetActive(false);
            AnimationIsPlaying = false;
            callback?.Invoke();
        });

        return true;
    }
}