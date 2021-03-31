using Character;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWidget : GameHUDWidget
{
    private ItemDisplayPanel ItemDisplayPanel;

    private List<CategorySelectButton> CategoryButtons;
    private PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = FindObjectOfType<PlayerController>();
        CategoryButtons = GetComponentsInChildren<CategorySelectButton>().ToList();
        ItemDisplayPanel = GetComponentInChildren<ItemDisplayPanel>();

        //Initilzie all buttons
        foreach (CategorySelectButton button in CategoryButtons)
        {
            button.Initialize(this);
        }
    }

    private void OnEnable()
    {
        //If we dont have player controller or inventory
        if(!PlayerController || !PlayerController.Inventory)
        {
            return;
        }

        //If inventory is empty
        if(PlayerController.Inventory.GetItemCount() <= 0)
        {
            return;
        }

        //Populate all item
        ItemDisplayPanel.PopulatePanel(PlayerController.Inventory.GetItemsOfCategory(ItemCategory.None));
    }

    public void SelectCategory(ItemCategory category)
    {
        //If we dont have player controller or inventory
        if (!PlayerController || !PlayerController.Inventory)
        {
            return;
        }

        //If inventory is empty
        if (PlayerController.Inventory.GetItemCount() <= 0)
        {
            return;
        }

        //Get item of this category
        ItemDisplayPanel.PopulatePanel(PlayerController.Inventory.GetItemsOfCategory(category));
    }
}
