using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IconSlot : MonoBehaviour
{
    private ItemScriptables Item;

    private Button ItemButton;
    private TMP_Text ItemText;

    [SerializeField] private ItemSlotAmountWidget AmountWidget;
    [SerializeField] private ItemSlotEquippedWidget EquippedWidget;

    private void Awake()
    {
        ItemButton = GetComponent<Button>();
        ItemText = GetComponentInChildren<TMP_Text>();
        //AmountWidget = GetComponentInChildren<ItemSlotAmountWidget>();
        //EquippedWidget = GetComponentInChildren<ItemSlotEquippedWidget>();
    }

    public void Initialize(ItemScriptables item)
    {
        Item = item;
        ItemText.text = item.Name;
        AmountWidget.Initialize(item);
        EquippedWidget.Initialize(item);


        //add event
        ItemButton.onClick.AddListener(UseItem);
        Item.OnItemDestroyed += OnItemDestroyed; //If item used, it destroy it self, and icon should also get destroyed

    }

    public void UseItem()
    {
        Debug.Log($"{Item.Name} - Item Used");
        Item.UseItem(Item.Controller);
    }

    private void OnItemDestroyed()
    {
        Item = null;
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        if(Item == null)
        {
            return;
        }
        Item.OnItemDestroyed -= OnItemDestroyed; //If item used, it destroy it self, and icon should also get destroyed
    }
}
