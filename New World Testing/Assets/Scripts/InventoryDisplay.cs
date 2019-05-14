using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    public Image weaponImage;
    public Text weaponText;
    public Image armourImage;
    public Text armourText;
    public Image backpackImage;
    public Text backpackText;

    public Text rationTotal;
    public Text ropeTotal;
    public Text baitTotal;
    public Text medicineTotal;
    public Text coinCurTotal;
    public Text coinExpTotal;

    public ItemAlpha items;
    private int expCoins;
    
    //public void UpdateEquippedItems()
    //{
    //    for (int i = 0; i < items.m_eqippableItems.Capacity; i++)
    //    {
    //        if (items.m_eqippableItems[i].equipped)
    //        {
    //            if (items.m_eqippableItems[i].weapon)
    //            {
    //                weaponImage.sprite = items.m_eqippableItems[i].displayImage;
    //                weaponText.text = items.m_eqippableItems[i].itemName;
    //            }
    //            else
    //            {
    //                armourImage.sprite = items.m_eqippableItems[i].displayImage;
    //                armourText.text = items.m_eqippableItems[i].itemName;
    //            }
    //        }
    //    }


    //    for (int i = 0; i < items.m_useableItems.Capacity; i++)
    //    {
    //        if (items.m_useableItems[i].equipped)
    //        {
    //            backpackImage.sprite = items.m_useableItems[i].displayImage;
    //            backpackText.text = items.m_useableItems[i].itemName;
    //        }
    //    }
    //}

    public void UpdateEquippedItems(ItemsList weapon, ItemsList armour, ItemsList backpack)
    {

        weaponImage.sprite = weapon.displayImage;
        weaponText.text = weapon.itemName;

        armourImage.sprite = armour.displayImage;
        armourText.text = armour.itemName;

        backpackImage.sprite = backpack.displayImage;
        backpackText.text = backpack.itemName;

    }

    public void UpdateItemsDisplay()
    {
        rationTotal.text = items.m_useableItems[3].curHeld.ToString();
        ropeTotal.text = items.m_useableItems[6].curHeld.ToString();
        baitTotal.text = items.m_useableItems[4].curHeld.ToString();
        medicineTotal.text = items.m_useableItems[5].curHeld.ToString();

        coinCurTotal.text = items.ReturnCoins().ToString();
        expCoins += items.ExpectedCoins();
        coinExpTotal.text = expCoins.ToString();
    }

    public void ResetExpectedCoins()
    {
        expCoins = 0;
        coinExpTotal.text = "";
    }
}
