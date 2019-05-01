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

    public Text nutTotal;

    public void EqippableItems(List<ItemsList> items)
    {
        for (int i = 0; i < items.Capacity; i++)
        {
            Debug.Log(items[i].ReturnName());
        }
    }

    public void UpdateInventoryDisplay(ItemsList item,  int update)
    {
        if (update == 0)
        {
            if (item.weapon)
            {
                Debug.Log("Into Update");
                weaponImage.sprite = item.displayImage;
                weaponText.text = item.itemName;
            }
            else
            {
               armourImage.sprite = item.displayImage;
               armourText.text = item.itemName;
            }
        }

        else if (update == -1)
        {
            if (item.equipped)
            {
                backpackImage.sprite = item.displayImage;
                backpackText.text = item.itemName;
            }
        }

        else
        {
            item.curHeld += update;
            nutTotal.text = item.curHeld.ToString();
        }
    }
}
