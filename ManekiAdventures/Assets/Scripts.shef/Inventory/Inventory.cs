﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20; //sets the inventory size to be 20 slots

    public List<Item> items = new List<Item>(); //allows items to have different attributes

    public bool Add (Item item) //adds item to inventory
    {


            if(items.Count >= space)
            {
                Debug.Log("Not enough room."); //debug to show that there is not enough space in inventory
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();

        return true;
    }

    

    public void Remove(Item item) //if the "X" is hit, removes item from inventory
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                items.RemoveAt(i);
                if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke();
                break;
            }
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


}
