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

    public Image weaponImage;
    public Text weaponText;
    public DisplayPanel weaponPanel;
    public Image armourImage;
    public Text armourText;
    public Image backpackImage;
    public Text backpackText;

    public Text coinTotal;

    public ItemAlpha items;

    public Button option01;
    public Button option02;
    public Button option03;
    public Button option04;
    public Button option05;

    public Text[] priceCheck;
    private string[] priceGet;

    private int temp1;
    private int temp2;
    private int temp3;
    private int temp4;
    private int temp5;

    public int curMoney;
    public Text moneyDisplay;

    private bool isFifth = false;
    public bool selectedWeapon;
    public bool selectedArmour;
    public bool selectedBackpack;


    public void Start()
    {
        priceGet = new string[] { "", "", "", "", ""};
        for(int i = 0; i < items.m_eqippableItems.Capacity; i++)
        {
            if(items.m_eqippableItems[i].equipped && items.m_eqippableItems[i].weapon)
            {
                currentWeapon = items.m_eqippableItems[i];
                weaponNum = i;
                weaponImage.sprite = currentWeapon.displayImage;
                weaponText.text = currentWeapon.itemName;
            }
            if(items.m_eqippableItems[i].equipped && !items.m_eqippableItems[i].weapon)
            {
                currentArmour = items.m_eqippableItems[i];
                armourNum = i;
                armourImage.sprite = currentArmour.displayImage;
                armourText.text = currentArmour.itemName;
            }
        }
        for (int i = 0; i < items.m_useableItems.Capacity; i++)
        {
            if(items.m_useableItems[i].equipped)
            {
                currentBackpack = items.m_useableItems[i];
                backpackNum = i;
                backpackImage.sprite = currentBackpack.displayImage;
                backpackText.text = currentBackpack.itemName;
            }
        }
        GetCoins();
        DisplayWares();
    }

    public void DisplayWares()
    {
        selectedArmour = false;
        selectedBackpack = false;
        selectedWeapon = false;

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
            priceGet[4] = CheckPrice(currentBackpack, items.m_useableItems[rand]);
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
        priceGet[0] = CheckPrice(currentWeapon, items.m_eqippableItems[rand]);
        temp1 = rand;

        do
        {
            rand = Random.Range(0, 7);
        }
        while (items.m_eqippableItems[rand].itemName == currentWeapon.itemName || items.m_eqippableItems[rand].itemName == option01.GetComponentInChildren<Text>().text);

        option02.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        priceGet[1] = CheckPrice(currentWeapon, items.m_eqippableItems[rand]);
        temp2 = rand;

        do
        {
            rand = Random.Range(7, 13);
        }
        while (items.m_eqippableItems[rand].itemName == currentArmour.itemName);

        option03.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        priceGet[2] = CheckPrice(currentArmour, items.m_eqippableItems[rand]);
        temp3 = rand;

        do
        {
            rand = Random.Range(7, 13);
        }
        while (items.m_eqippableItems[rand].itemName == currentArmour.itemName || items.m_eqippableItems[rand].itemName == option03.GetComponentInChildren<Text>().text);

        option04.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        priceGet[3] = CheckPrice(currentArmour, items.m_eqippableItems[rand]);
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
            FindObjectOfType<ItemAlpha>().SendCoins(currentWeapon.cost - items.m_eqippableItems[temp1].cost);
            currentWeapon = items.m_eqippableItems[temp1];
            weaponNum = temp1;
            selectedWeapon = true;
            Debug.Log(items.m_eqippableItems[temp1].itemName);
        }

        else if (selected == 2)
        {
            items.m_eqippableItems[weaponNum].equipped = false;
            items.m_eqippableItems[temp2].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentWeapon.cost - items.m_eqippableItems[temp2].cost);
            currentWeapon = items.m_eqippableItems[temp2];
            weaponNum = temp2;
            selectedWeapon = true;
            Debug.Log(items.m_eqippableItems[temp2].itemName);
        }

        else if (selected == 3)
        {
            items.m_eqippableItems[armourNum].equipped = false;
            items.m_eqippableItems[temp3].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentArmour.cost - items.m_eqippableItems[temp3].cost);
            currentArmour = items.m_eqippableItems[temp3];
            armourNum = temp3;
            selectedArmour = true;
            Debug.Log(items.m_eqippableItems[temp3].itemName);
        }

        else if (selected == 4)
        {
            items.m_eqippableItems[armourNum].equipped = false;
            items.m_eqippableItems[temp4].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentArmour.cost - items.m_eqippableItems[temp4].cost);
            currentArmour = items.m_eqippableItems[temp4];
            armourNum = temp4;
            selectedArmour = true;
            Debug.Log(items.m_eqippableItems[temp4].itemName);
        }

        else
        {
            items.m_useableItems[backpackNum].equipped = false;
            items.m_useableItems[temp5].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentBackpack.cost - items.m_eqippableItems[temp5].cost);
            currentBackpack = items.m_eqippableItems[temp5];
            backpackNum = temp5;
            selectedBackpack = true;
            option05.interactable = false;
        }

        UpdateInventory();
        GetCoins();
        CheckCost(isFifth);
    }


    public void CheckCost(bool backpack)
    {
        string nope = "Not enough GPs";
        if (selectedWeapon)
        {
            priceCheck[0].text = "Already brought";
            priceCheck[1].text = "Already brought";
            option01.interactable = false;
            option02.interactable = false;
        }
        else
        {
            if (items.m_eqippableItems[temp1].cost > (curMoney + currentWeapon.cost))
            {
                option01.interactable = false;
                priceCheck[0].text = nope;
            }
            else
            {
                option01.interactable = true;
                priceGet[0] = CheckPrice(currentWeapon, items.m_eqippableItems[temp1]);
                priceCheck[0].text = priceGet[0];
            }

            if (items.m_eqippableItems[temp2].cost > (curMoney + currentWeapon.cost))
            {
                option02.interactable = false;
                priceCheck[1].text = nope;
            }
            else
            {
                option02.interactable = true;
                priceGet[1] = CheckPrice(currentWeapon, items.m_eqippableItems[temp2]);
                priceCheck[1].text = priceGet[1];
            }
        }

        if (selectedArmour)
        {
            priceCheck[2].text = "Already brought";
            priceCheck[3].text = "Already brought";
            option03.interactable = false;
            option04.interactable = false;
        }
        else
        {
            if (items.m_eqippableItems[temp3].cost > (curMoney + currentArmour.cost))
            {
                option03.interactable = false;
                priceCheck[2].text = nope;
            }
            else
            {
                option03.interactable = true;
                priceGet[2] = CheckPrice(currentWeapon, items.m_eqippableItems[temp3]);
                priceCheck[2].text = priceGet[2];
            }

            if (items.m_eqippableItems[temp4].cost > (curMoney + currentArmour.cost))
            {
                option04.interactable = false;
                priceCheck[3].text = nope;
            }
            else
            {
                option04.interactable = true;
                priceGet[3] = CheckPrice(currentWeapon, items.m_eqippableItems[temp4]);
                priceCheck[3].text = priceGet[3];
            }
        }

        if (selectedBackpack)
        {
            priceCheck[4].text = "Already brought";
            option05.interactable = false;
        }
        else
        {
            if (backpack)
            {
                if (items.m_useableItems[temp5].cost > (curMoney + currentBackpack.cost))
                {
                    option05.interactable = false;
                    priceCheck[4].text = nope;
                }
                else
                {
                    option05.interactable = true;
                    priceGet[0] = CheckPrice(currentWeapon, items.m_useableItems[temp5]);
                    priceCheck[4].text = priceGet[4];
                }
            }
        }
        priceCheck[5].text = items.m_eqippableItems[temp1].cost.ToString() + "GPs";
        priceCheck[6].text = items.m_eqippableItems[temp2].cost.ToString() + "GPs";
        priceCheck[7].text = items.m_eqippableItems[temp3].cost.ToString() + "GPs";
        priceCheck[8].text = items.m_eqippableItems[temp4].cost.ToString() + "GPs";
        priceCheck[9].text = items.m_useableItems[temp5].cost.ToString() + "GPs";
    }

    private void GetCoins()
    {
        curMoney = FindObjectOfType<ItemAlpha>().ReturnCoins();
        coinTotal.text = curMoney.ToString();
    }

    public void UpdateInventory()
    {
        weaponImage.sprite = currentWeapon.displayImage;
        weaponText.text = currentWeapon.itemName;

        armourImage.sprite = currentArmour.displayImage;
        armourText.text = currentArmour.itemName;

        backpackImage.sprite = currentBackpack.displayImage;
        backpackText.text = currentBackpack.itemName;
    }

    public string CheckPrice(ItemsList current, ItemsList buying)
    {
        string total = "";
        int equals = current.cost - buying.cost;
        if (equals > 0)
        {
            total = "You gain " + equals.ToString() + "GPs";
        }
        else
        {
            equals = -equals;
            total = "You lose " + equals.ToString() + "GPs";
        }

        return total;
    }
}
