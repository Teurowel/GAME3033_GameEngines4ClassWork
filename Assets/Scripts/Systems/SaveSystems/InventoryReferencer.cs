using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class holds all item scriptable object
//When we load game, player controller will use this to populate inventory
public class InventoryReferencer : MonoBehaviour
{
    public static InventoryReferencer Instance;

    [SerializeField] private List<ItemScriptables> ItemList = new List<ItemScriptables>(); //this will hold all references to item

    private Dictionary<string, ItemScriptables> ItemDictionary = new Dictionary<string, ItemScriptables>(); //dictionary for all item

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        //Convert list to dictionary
        foreach (ItemScriptables itemScriptable in ItemList)
        {
            ItemDictionary.Add(itemScriptable.Name, itemScriptable);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public ItemScriptables GetItemReference(string itemName) =>
        ItemDictionary.ContainsKey(itemName) ? ItemDictionary[itemName] : null;
}
