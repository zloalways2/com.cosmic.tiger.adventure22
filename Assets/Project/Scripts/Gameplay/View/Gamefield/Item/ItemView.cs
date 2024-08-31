using UnityEngine;

[RequireComponent(typeof(Item))]
public class ItemView : ButtonListener
{
    [SerializeField] private ItemIconView _icon;
    
    private Item _item;

    protected override void HandleAwake()
    {
        _item = GetComponent<Item>();

        _item.Deselected += _icon.ForceHide;
        _icon.Initialized += SetItemType;
    }

    protected override void Listen()
    {
        ToggleSelected();
    }

    private void SetItemType()
    {
        _item.TrySetType(_icon.IconName);
    }

    private void ToggleSelected()
    {
        if (_item.IsSolved) return;

        if (_item.IsSelected) Deselect();
        else Select();
    }

    private void Select()
    {
        _icon.TryShow(() => _item.Select());
    }

    private void Deselect()
    {
        _icon.TryHide(() => _item.Deselect());
    }

    private void OnDestroy()
    {
        _item.Deselected -= _icon.ForceHide;
        _icon.Initialized -= SetItemType;
    }
}