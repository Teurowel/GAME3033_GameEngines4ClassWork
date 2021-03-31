using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private List<ItemScriptables> Items = new List<ItemScriptables>();

    private PlayerController Controller;

    

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
    }

    public List<ItemScriptables> GetItemList() => Items;
    public int GetItemCount() => Items.Count;

    public ItemScriptables FindItem(string itemName)
    {
        //Find item that has the same name
        return Items.Find((invItem) => invItem.Name == itemName);
    }

    

    public void AddItem(ItemScriptables item, int amount = 0)
    {
        int itemIndex = Items.FindIndex(itemScript => itemScript.Name == item.Name);

        //If we found item
        if(itemIndex != -1)
        {
            ItemScriptables listItem = Items[itemIndex];

            //Is this item stackabale and has less than max amount?
            if(listItem.Stackable && listItem.Amount < listItem.MaxStack)
            {
                listItem.ChangeAmount(item.Amount);
            }
        }
        else
        {
            if(item == null)
            {
                return;
            }

            //copy item scriptable, we shouldn't modify original scriptable object
            ItemScriptables itemClone = Instantiate(item);
            itemClone.Initialize(Controller);
            itemClone.SetAmount(amount <= 1 ? item.Amount : amount); //if amount is 0, use default amount, if not use custom amount
            Items.Add(itemClone);
        }

    }

    public void DeleteItem(ItemScriptables item)
    {
        int itemIndex = Items.FindIndex(listItem => listItem.Name == item.Name);

        //If we couldn't find item
        if(itemIndex == -1)
        {
            return;
        }

        Items.Remove(item);
    }

    public List<ItemScriptables> GetItemsOfCategory(ItemCategory itemCategory)
    {
        if(Items == null || Items.Count <= 0)
        {
            return null;
        }

        //If we didn't specify category, return entire item list
        if(itemCategory == ItemCategory.None)
        {
            return Items;
        }

        //Find item that has the same category
        return Items.FindAll(item => item.ItemCategory == itemCategory);
    }
}
