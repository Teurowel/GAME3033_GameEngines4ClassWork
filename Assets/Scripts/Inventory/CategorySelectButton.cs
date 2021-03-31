using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class CategorySelectButton : MonoBehaviour
{
    [SerializeField] private ItemCategory Category;

    //REferences
    private Button SelectButton;
    private InventoryWidget InventoryWidget;


    private void Awake()
    {
        SelectButton = GetComponent<Button>();
        SelectButton.onClick.AddListener(OnClick); //Add event
    }

    public void Initialize(InventoryWidget inventoryWidget)
    {
        InventoryWidget = inventoryWidget;
    }

    private void OnClick()
    {
        if(InventoryWidget == null)
        {
            return;
        }

        InventoryWidget.SelectCategory(Category);
    }
}
