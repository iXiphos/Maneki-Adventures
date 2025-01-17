﻿using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    public GameObject craftingSystem;

    Item item;

    public void AddItem (Item newItem) //adds icon of item to inveotory
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true; //displays "X" button for each slot
    }

    public void ClearSlot() //deletes sprite of icon for each item removed
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton() //removes item
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem(GameObject crafting) //button to use item in inventory
    {
        if (item != null)
        {

            if (item.Attribute != attribute.empty && item.Discriptor != discriptor.empty)
            {
                GameObject.Find("KIKI").GetComponent<tossPotion>().createPotion(item);
                StartCoroutine(GameObject.Find("KIKI").GetComponent<tossPotion>().createTarget());
                GameObject.Find("KIKI").GetComponent<tossPotion>().potionItem = item;
               Inventory.instance.Remove(item);
            }
            else if(craftingSystem.activeSelf)
            {
                if(item.Attribute != attribute.empty)
                {
                    if (crafting.GetComponent<PotionCreation>().piece1 == null)
                    {
                        crafting.GetComponent<PotionCreation>().piece1 = item;
                        Inventory.instance.Remove(item);
                    }
                    else
                    {
                        Inventory.instance.Add(crafting.GetComponent<PotionCreation>().piece1);
                        crafting.GetComponent<PotionCreation>().piece1 = item;
                        Inventory.instance.Remove(item);
                    }
                }
                else if(item.Discriptor != discriptor.empty)
                {
                    if (crafting.GetComponent<PotionCreation>().piece2 == null)
                    {
                        crafting.GetComponent<PotionCreation>().piece2 = item;
                        Inventory.instance.Remove(item);
                    }
                    else
                    {
                        Inventory.instance.Add(crafting.GetComponent<PotionCreation>().piece2);
                        crafting.GetComponent<PotionCreation>().piece2 = item;
                        Inventory.instance.Remove(item);
                    }
                }
            }
            //gameObject.GetComponent<InventorySlot>().ClearSlot();
        }
    }

    // Get the name of the item contained in this slot, returns an empty string if there is no item
    public string getItemName()
    {
        if(item != null)
        {
            return item.name;
        }
        else
        {
            return "";
        }
    }

}
