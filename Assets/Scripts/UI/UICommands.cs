using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICommands : MonoBehaviour
{
    GameObject player;
    Inventory inventory;
    EquipmentManager equipmentManager;

    public Transform itemsParent;
    private InventorySlot[] inventorySlots;

    public Transform equipmentsParent;
    private EquipmentSlot[] equipmentSlots;

    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateInventory;

        equipmentManager = EquipmentManager.instance;
        equipmentManager.onEquipmentChanged += UpdateEquipment;

        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
        equipmentSlots = equipmentsParent.GetComponentsInChildren<EquipmentSlot>();

        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (isOpen)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                player.GetComponent<PlayerMovement>().frozen = false;
                isOpen = !isOpen;

            }
            else
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                player.GetComponent<PlayerMovement>().frozen = true;
                isOpen = !isOpen;


            }
        }
    }

    void UpdateInventory()
    {

        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(i<inventory.items.Count)
            {
                inventorySlots[i].AddItem(inventory.items[i]);
            } else
            {
                inventorySlots[i].ClearSlot();
            }
        }

    }

    void UpdateEquipment(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            equipmentSlots[(int)newItem.slot].AddItem(newItem);
        }
        else
        {
            equipmentSlots[(int)oldItem.slot].ClearSlot();
        }
        //for (int i = 0; i < equipmentSlots.Length; i++)
        //{
        //    if (equipmentManager.currentEquipment[i] != null)
        //    {
        //        Debug.Log("Equipped: " + newItem.name);
        //        equipmentSlots[i].AddItem(newItem);
        //    }
        //    else
        //    {
        //        equipmentSlots[i].ClearSlot();
        //    }
        //}
    }

}
