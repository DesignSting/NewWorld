using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAlpha : MonoBehaviour {

    public static ItemAlpha Instance = null;

    public List<ItemsList> m_ItemList = new List<ItemsList>();
    public List<ItemsList> m_eqippableItems = new List<ItemsList>();
    public List<ItemsList> m_useableItems = new List<ItemsList>();

    public Text nutTotal;

    public void Start()
    {
        nutTotal.text = m_ItemList[1].curHeld.ToString();
    }

    public void EqippableItems()
    {
        FindObjectOfType<InventoryDisplay>().EqippableItems(m_eqippableItems);
    }

    public void UpdateInventory(string name, int amount)
    {
        int itemNumber = 0;
        int itemType = 0;
        if(amount == 0)
        {
            for(int i = 0; i < m_eqippableItems.Capacity; i++)
            {
                if(name == m_eqippableItems[i].itemName)
                {
                    m_eqippableItems[i].equipped = false;
                    itemNumber = i;
                    itemType = 1;
                    FindObjectOfType<InventoryDisplay>().UpdateInventoryDisplay(m_eqippableItems[itemNumber], itemType);
                    break;
                }
            }
            for (int i = 0; i < m_useableItems.Capacity; i++)
            {
                Debug.Log(m_useableItems[i].itemName);
                if (name == m_useableItems[i].itemName)
                {
                    itemNumber = i;
                    itemType = 2;
                    FindObjectOfType<InventoryDisplay>().UpdateInventoryDisplay(m_useableItems[itemNumber], itemType);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < m_ItemList.Capacity; i++)
            {
                if (name == m_ItemList[i].itemName)
                {
                    itemNumber = i;
                    break;
                }
            }
            FindObjectOfType<InventoryDisplay>().UpdateInventoryDisplay(m_ItemList[itemNumber], amount);
        }
    }


    public string ReturnName(ItemsList itemsList)
    {
        return itemsList.ReturnName();
    }

    public void Test()
    {
        UpdateInventory("Small Backpack", 0);
    }

}
