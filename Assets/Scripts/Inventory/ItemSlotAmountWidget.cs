using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSlotAmountWidget : MonoBehaviour
{
    [SerializeField] private TMP_Text AmountText;

    private ItemScriptables Item;

    private void Awake()
    {
        HideWidget();
    }

    public void ShowWidget()
    {
        gameObject.SetActive(true);
    }

    public void HideWidget()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(ItemScriptables item)
    {
        //If item is stackable
        if(item.Stackable)
        {
            Item = item;
            ShowWidget();
            Item.OnAmountChange += OnAmountChange;
            OnAmountChange();
        }
    }

    private void OnAmountChange()
    {
        AmountText.text = Item.Amount.ToString();
    }

    private void OnDisable()
    {
        if(Item == null)
        {
            return;
        }

        Item.OnAmountChange -= OnAmountChange; //remove event
    }
}
