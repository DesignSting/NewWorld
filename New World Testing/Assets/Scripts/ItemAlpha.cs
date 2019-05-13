using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAlpha : MonoBehaviour {

    public static ItemAlpha Instance = null;

    public List<ItemsList> m_ItemList = new List<ItemsList>();
    public List<ItemsList> m_eqippableItems = new List<ItemsList>();
    public List<ItemsList> m_useableItems = new List<ItemsList>();

    private int currentWeapon;
    private int currentArmour;
    private int currentBackpack;

    public int coins;
    public int health;

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

    public string CheckPrice(ItemsList current, ItemsList buying)
    {
        string total = "";
        int equals = current.cost - buying.cost;
        if (equals >= 1)
        {
            total = "You gain " + equals.ToString() + "GPs";
        }

        else if(equals == 0)
        {
            total = "Equal trade";
        }
        else
        {
            equals = -equals;
            total = "You lose " + equals.ToString() + "GPs";
        }

        return total;
    }

    public void NewGame()
    {
        for(int i = 0; i < m_ItemList.Capacity; i++)
        {
            if(m_ItemList[i].curHeld > 0)
            {
                m_ItemList[i].curHeld = 0;
            }
        }

        m_eqippableItems[currentWeapon].equipped = false;
        m_eqippableItems[currentArmour].equipped = false;
        m_useableItems[currentBackpack].equipped = false;

        m_eqippableItems[0].equipped = true;
        m_eqippableItems[12].equipped = true;
        m_useableItems[0].equipped = true;
        currentWeapon = 0;
        currentArmour = 12;
        currentBackpack = 0;

        coins = 100;
        FindObjectOfType<StoreFront>().NewGame();
    }

    public void CurrentWeapon(int i)
    {
        currentWeapon = i;
        m_eqippableItems[i].equipped = true;
    }

    public ItemsList CurrentWeapon()
    {
        return m_eqippableItems[currentWeapon];
    }

    public void CurrentArmour(int i)
    {
        currentArmour = i;
        m_eqippableItems[i].equipped = true;
    }

    public ItemsList CurrentArmour()
    {
        return m_eqippableItems[currentArmour];
    }

    public void CurrentBackpack(int i)
    {
        currentBackpack = i;
        m_useableItems[i].equipped = true;
    }

    public ItemsList CurrentBackpack()
    {
        return m_useableItems[currentBackpack];
    }

    public void CheckEquipped()
    {
        for(int i = 0; i < m_eqippableItems.Capacity; i++)
        {
            if(m_eqippableItems[i].equipped)
            {
                if(m_eqippableItems[i].weapon)
                {
                    currentWeapon = i;
                }
                else
                {
                    currentArmour = i;
                }
            }
        }

        for(int i = 0; i< m_useableItems.Capacity; i++)
        {
            if(m_useableItems[i].equipped)
            {
                currentBackpack = i;
            }
        }

    }

    public void CurrentHealth(int i)
    {
        health = i;
    }

    public int CurrentHealth()
    {
        return health;
    }

    public int CurrentWeaponNum()
    {
        return currentWeapon;
    }

    public int CurrentArmourNum()
    {
        return currentArmour;
    }

    public int CurrentBackpackNum()
    {
        return currentBackpack;
    }

    public void StripEquipped()
    {
        for(int i = 0; i < m_eqippableItems.Capacity; i++)
        {
            m_eqippableItems[i].equipped = false;
        }

        for (int i = 0; i < m_useableItems.Capacity; i++)
        {
            m_useableItems[i].equipped = false;
        }
        coins = 0;
        health = 0;
    }



    public void LoadSaveGame(int weapon, int armour, int backpack, int coins, int health)
    {
        StripEquipped();
        CurrentWeapon(weapon);
        CurrentArmour(armour);
        CurrentBackpack(backpack);
        SendCoins(coins);
        CurrentHealth(health);

        FindObjectOfType<StoreFront>().LoadGame(weapon, armour, backpack);

        Debug.Log(m_eqippableItems[currentWeapon].itemName);
    }
}
