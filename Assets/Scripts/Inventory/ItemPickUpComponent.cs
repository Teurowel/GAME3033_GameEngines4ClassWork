using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class ItemPickUpComponent : MonoBehaviour
{
    [SerializeField] ItemScriptables PickUpItem;

    [Tooltip("Manual Override for Drop Amount, if left at -1, it will use the amount from the scriptable object.")]
    [SerializeField] int Amount = -1;

    [SerializeField] private MeshRenderer PropMeshRenderer;
    [SerializeField] private MeshFilter PropMeshFilter;
    private ItemScriptables ItemInsatnce; //To make sure we are not editing original ItemScriptables(Original item data)

    private void Awake()
    {
        if(PropMeshRenderer == null)
        {
            GetComponentInChildren<MeshRenderer>();
        }

        if (PropMeshFilter == null)
        {
            GetComponentInChildren<MeshFilter>();
        }

        Instantiate();
    }

    public void Instantiate()
    {
        ItemInsatnce = Instantiate(PickUpItem);
        if(Amount > 0)
        {
            ItemInsatnce.SetAmount(Amount);
        }

        ApplyMesh();
    }


    //Change pick up's mesh rendrer(mateiral) and mesh filter(mesh) to item prefab
    private void ApplyMesh()
    {
        if(PropMeshFilter)
        {
            PropMeshFilter.mesh = PickUpItem.ItemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;
        }

        if(PropMeshRenderer)
        {
            //Prefab uses shared materials, so make sure not to use materials
            PropMeshRenderer.material = PickUpItem.ItemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterial;
        }
    }

    private void OnValidate()
    {
        ApplyMesh();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If it's not a player
        if(other.CompareTag("Player") == false)
        {
            return;
        }

        ItemInsatnce.UseItem(other.GetComponent<PlayerController>());
    }
}
