using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemsList
{

    public string itemName;
    public Sprite displayImage;
    public bool weapon;                     //True if Weapon, False is Armour
    public int curHeld;
    public int maxHeld;
    public int cost;
    public bool equipped;

    public ItemsList(string newItemName, Sprite newDisplayImage, bool newWeapon, int newCurHeld, int newMaxHeld, int newCost, bool newEquipped)
    {
        itemName = newItemName;
        displayImage = newDisplayImage;
        weapon = newWeapon;
        curHeld = newCurHeld;
        maxHeld = newMaxHeld;
        cost = newCost;
        equipped = newEquipped;
    }

    public string ReturnName()
    {
        return itemName;
    }
}
