using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayPanel : MonoBehaviour
{
    [SerializeField] private GameObject ItemSlotPrefab;

    private RectTransform RectTransform;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        WipeChildren();
    }

    //Populating item
    public void PopulatePanel(List<ItemScriptables> itemList)
    {
        WipeChildren();

        //Iterate item list and make item
        foreach(ItemScriptables item in itemList)
        {
            IconSlot icon = Instantiate(ItemSlotPrefab, RectTransform).GetComponent<IconSlot>();
            icon.Initialize(item);
        }
    }

    private void WipeChildren()
    {
        //delete all children under RectTransform
        foreach(RectTransform child in RectTransform)
        {
            Destroy(child.gameObject);
        }
        RectTransform.DetachChildren();
    }
}
