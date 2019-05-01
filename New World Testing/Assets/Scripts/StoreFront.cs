using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreFront : MonoBehaviour
{
    public ItemsList currentWeapon;
    private int weaponNum;
    public ItemsList currentArmour;
    private int armourNum;
    public ItemsList currentBackpack;
    private int backpackNum;

    public ItemAlpha items;

    public Button option01;
    public Button option02;
    public Button option03;
    public Button option04;
    public Button option05;

    private int temp1;
    private int temp2;
    private int temp3;
    private int temp4;
    private int temp5;

    public int curMoney;
    public Text moneyDisplay;

    public void Start()
    {
        for(int i = 0; i < items.m_eqippableItems.Capacity; i++)
        {
            if(items.m_eqippableItems[i].equipped && items.m_eqippableItems[i].weapon)
            {
                currentWeapon = items.m_eqippableItems[i];
                weaponNum = i;
            }
            if(items.m_eqippableItems[i].equipped && !items.m_eqippableItems[i].weapon)
            {
                currentArmour = items.m_eqippableItems[i];
                armourNum = i;
            }
        }
        for (int i = 0; i < items.m_useableItems.Capacity; i++)
        {
            if(items.m_useableItems[i].equipped)
            {
                currentBackpack = items.m_useableItems[i];
                backpackNum = i;
            }
        }
    }

    public void DisplayWares()
    {
        int rand = Random.Range(0, 100);
        bool isFifth = false;
        option05.gameObject.SetActive(true);
        if (rand > 79)
        {
            do
            {
                rand = Random.Range(0, 3);
            }
            while (items.m_useableItems[rand].itemName == currentBackpack.itemName);

            option05.GetComponentInChildren<Text>().text = items.m_useableItems[rand].itemName;
            temp5 = rand;
            isFifth = true;
        }
        else
            option05.gameObject.SetActive(false);

        do
        {
            rand = Random.Range(0, 7);
        }
        while (items.m_eqippableItems[rand].itemName == currentWeapon.itemName);

        option01.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        temp1 = rand;

        do
        {
            rand = Random.Range(0, 7);
        }
        while (items.m_eqippableItems[rand].itemName == currentWeapon.itemName || items.m_eqippableItems[rand].itemName == option01.GetComponentInChildren<Text>().text);

        option02.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        temp2 = rand;

        do
        {
            rand = Random.Range(7, 13);
        }
        while (items.m_eqippableItems[rand].itemName == currentArmour.itemName);

        option03.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        temp3 = rand;

        do
        {
            rand = Random.Range(7, 13);
        }
        while (items.m_eqippableItems[rand].itemName == currentArmour.itemName || items.m_eqippableItems[rand].itemName == option03.GetComponentInChildren<Text>().text);

        option04.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        temp4 = rand;

        CheckCost(isFifth);
    }

    public void SellAllJunk()
    {
        int money = 0;
        for(int i = 0; i < items.m_ItemList.Capacity; i++)
        {
            if(items.m_ItemList[i].curHeld > 0)
            {
                money += (items.m_ItemList[i].curHeld * items.m_ItemList[i].cost);
                items.m_ItemList[i].curHeld = 0;
            }
        }
        FindObjectOfType<ItemAlpha>().SendCoins(curMoney);
    }

    public void Buy(Button clicked)
    {
        clicked.interactable = false;
        char[] array = clicked.name.ToCharArray();
        string temp = array[array.Length - 1].ToString();
        int selected = int.Parse(temp);
        if(selected == 1)
        {
            items.m_eqippableItems[weaponNum].equipped = false;
            items.m_eqippableItems[temp1].equipped = true;
            currentWeapon = items.m_eqippableItems[temp1];
            Debug.Log(items.m_eqippableItems[temp1].itemName);
        }

        else if (selected == 2)
        {
            items.m_eqippableItems[weaponNum].equipped = false;
            items.m_eqippableItems[temp2].equipped = true;
            currentWeapon = items.m_eqippableItems[temp2];
            Debug.Log(items.m_eqippableItems[temp2].itemName);
        }

        else if (selected == 3)
        {
            items.m_eqippableItems[armourNum].equipped = false;
            items.m_eqippableItems[temp3].equipped = true;
            currentArmour = items.m_eqippableItems[temp3];
            Debug.Log(items.m_eqippableItems[temp3].itemName);
        }

        else if (selected == 4)
        {
            items.m_eqippableItems[armourNum].equipped = false;
            items.m_eqippableItems[temp4].equipped = true;
            currentArmour = items.m_eqippableItems[temp4];
            Debug.Log(items.m_eqippableItems[temp4].itemName);
        }

        else
        {
            items.m_useableItems[backpackNum].equipped = false;
            items.m_useableItems[temp5].equipped = true;
            currentBackpack = items.m_eqippableItems[temp5];
        }

        FindObjectOfType<InventoryDisplay>().UpdateEquippedItems(currentWeapon, currentArmour, currentBackpack);
    }

    public void CheckCost(bool backpack)
    {
        GetCoins();
        if(items.m_eqippableItems[temp1].cost > curMoney)
        {
            option01.interactable = false;
        }
        else
            option01.interactable = true;

        if (items.m_eqippableItems[temp2].cost > curMoney)
        {
            option02.interactable = false;
        }
        else
            option02.interactable = true;

        if (items.m_eqippableItems[temp3].cost > curMoney)
        {
            option03.interactable = false;
        }
        else
            option03.interactable = true;

        if (items.m_eqippableItems[temp4].cost > curMoney)
        {
            option04.interactable = false;
        }
        else
            option04.interactable = true;

        if (backpack)
        {
            if (items.m_useableItems[temp5].cost > curMoney)
                option05.interactable = false;
            else
                option05.interactable = true;
        }
    }

    private void GetCoins()
    {
        curMoney = FindObjectOfType<ItemAlpha>().ReturnCoins();
    }
}
