using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour {

    public int currentFunds;

    public Image weaponImage;
    public Text weaponText;
    public Image armourImage;
    public Text armourText;
    public Image backpackImage;
    public Text backpackText;

    public Text coinTotal;

    public Text nutTotal;
    public Text berryTotal;
    public Text dogHideTotal;
    public Text dogMeatTotal;
    public Text jeweleryTotal;
    public Text featherTotal;
    public Text boneTotal;
    public Text femurTotal;
    public Text rabbitHideTotal;
    public Text rabbitMeatTotal;
    public Text antCarapaceTotal;
    public Text paperTotal;
    public Text rationTotal;

    public ItemAlpha items;

    public void UpdateEquippedItems()
    {
        for (int i = 0; i < items.m_eqippableItems.Capacity; i++)
        {
            if (items.m_eqippableItems[i].equipped)
            {
                if (items.m_eqippableItems[i].weapon)
                {
                    weaponImage.sprite = items.m_eqippableItems[i].displayImage;
                    weaponText.text = items.m_eqippableItems[i].itemName;
                }
                else
                {
                    armourImage.sprite = items.m_eqippableItems[i].displayImage;
                    armourText.text = items.m_eqippableItems[i].itemName;
                }
            }
        }


        for (int i = 0; i < items.m_useableItems.Capacity; i++)
        {
            if (items.m_eqippableItems[i].equipped)
            {
                backpackImage.sprite = items.m_useableItems[i].displayImage;
                backpackText.text = items.m_useableItems[i].itemName;
            }
        }
    }

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
        nutTotal.text = items.m_ItemList[0].curHeld.ToString();
        berryTotal.text = items.m_ItemList[1].curHeld.ToString();
        dogHideTotal.text = items.m_ItemList[2].curHeld.ToString();
        dogMeatTotal.text = items.m_ItemList[3].curHeld.ToString();
        jeweleryTotal.text = items.m_ItemList[4].curHeld.ToString();
        featherTotal.text = items.m_ItemList[5].curHeld.ToString();
        boneTotal.text = items.m_ItemList[6].curHeld.ToString();
        femurTotal.text = items.m_ItemList[7].curHeld.ToString();
        rabbitHideTotal.text = items.m_ItemList[8].curHeld.ToString();
        rabbitMeatTotal.text = items.m_ItemList[9].curHeld.ToString();
        antCarapaceTotal.text = items.m_ItemList[10].curHeld.ToString();
        paperTotal.text = items.m_ItemList[11].curHeld.ToString();
        rationTotal.text = items.m_useableItems[3].curHeld.ToString();
        coinTotal.text = items.coins.ToString();
    }
}
