using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAlpha : MonoBehaviour {

    public static ItemAlpha Instance = null;

    public List<ItemsList> m_ItemList = new List<ItemsList>();
    public List<ItemsList> m_eqippableItems = new List<ItemsList>();
    public List<ItemsList> m_useableItems = new List<ItemsList>();

    public int coins;

     public void UpdateItems(string name, int amount)
    {
        bool isFound = false;
        for(int i = 0; i < m_ItemList.Capacity; i++)
        {
            if(name == m_ItemList[i].itemName)
            {
                m_ItemList[i].curHeld += amount;
                isFound = true;
            }
        }
        if(!isFound)
        {
            for (int i = 0; i < m_useableItems.Capacity; i++)
            {
                if (name == m_useableItems[i].itemName)
                {
                    m_useableItems[i].curHeld += amount;
                    isFound = true;
                }
            }
        }
        FindObjectOfType<InventoryDisplay>().UpdateItemsDisplay();
    }

    public string ReturnName(ItemsList itemsList)
    {
        return itemsList.ReturnName();
    }

    public void AddCoins(int i)
    {
        coins += i;
    }

    public void EmptyItem(string name)
    {
        for (int i = 0; i < m_useableItems.Capacity; i++)
        {
            if (m_useableItems[i].itemName == name)
            {
                m_useableItems[i].curHeld =0;
            }
        }
    }

    public void RemoveItem(string name, int amount)
    {
        for(int i = 0; i < m_useableItems.Capacity; i++)
        {
            if(m_useableItems[i].itemName == name)
            {
                m_useableItems[i].curHeld -= amount;
                break;
            }
        }
    }

    public int ReturnCoins()
    {
        return coins;
    }

    public void SendCoins(int i)
    {
        coins += i;
    }

    public int ReturnRope()
    {
        return m_useableItems[6].curHeld;
    }
}
