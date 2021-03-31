using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotEquippedWidget : MonoBehaviour
{
    EquippableScriptable Equipable;
    [SerializeField] private Image EnabledIamge;

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
        //casting item to EquippableScriptable
        if (!(item is EquippableScriptable eqitem))
        {
            return;
        }

        //Save it to variable
        Equipable = eqitem;

        ShowWidget(); //SHow widget

        Equipable.OnEquipStatusChange += OnEquipmentChange; //add event
        OnEquipmentChange();
    }

    private void OnEquipmentChange()
    {
        //Enable and disable check image
        EnabledIamge.gameObject.SetActive(Equipable.Equipped);
    }

    private void OnDisable()
    {
        if(Equipable == null)
        {
            return;
        }

        Equipable.OnEquipStatusChange -= OnEquipmentChange; //remove event
    }
}
