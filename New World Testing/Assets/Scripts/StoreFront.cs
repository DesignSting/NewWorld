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

    public Image option01Image;
    public Image option02Image;
    public Image option03Image;
    public Image option04Image;
    public Image option05Image;

    public Text[] priceCheck;
    private string[] priceGet;

    private int temp1;
    private int temp2;
    private int temp3;
    private int temp4;
    private int temp5;

    public int curMoney;
    public Text moneyDisplay;

    public bool selectedWeapon;
    public bool selectedArmour;
    public bool selectedBackpack;
    private bool isFifth = false;


    public void Start()
    {
        priceGet = new string[] { "", "", "", "", "" };

    }

    public void NewGame()
    {
        currentWeapon = items.CurrentWeapon();
        currentArmour = items.CurrentArmour();
        currentBackpack = items.CurrentBackpack();
        weaponNum = 0;
        armourNum = 12;
        backpackNum = 0;
        UpdateInventoryDisplay();
        DisplayWares();
    }


    public void LoadGame(int weapon, int armour, int backpack)
    {
        weaponNum = weapon;
        armourNum = armour;
        backpackNum = backpack;

        currentWeapon = items.CurrentWeapon();
        currentArmour = items.CurrentArmour();
        currentBackpack = items.CurrentBackpack();
        UpdateInventoryDisplay();
        DisplayWares();
    }

    public void DisplayWares()
    {
        GetCoins();
        selectedArmour = false;
        selectedBackpack = false;
        selectedWeapon = false;

        int rand = Random.Range(0, 100);
        option05.gameObject.SetActive(true);
        if (rand > 79)
        {
            do
            {
                rand = Random.Range(0, 3);
            }
            while (items.m_useableItems[rand].itemName == currentBackpack.itemName);

            option05.GetComponentInChildren<Text>().text = items.m_useableItems[rand].itemName;
            option05Image.sprite = items.m_useableItems[rand].displayImage;
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
        option01Image.sprite = items.m_eqippableItems[rand].displayImage;
        priceGet[0] = CheckPrice(currentWeapon, items.m_eqippableItems[rand]);
        temp1 = rand;

        do
        {
            rand = Random.Range(0, 7);
        }
        while (items.m_eqippableItems[rand].itemName == currentWeapon.itemName || items.m_eqippableItems[rand].itemName == option01.GetComponentInChildren<Text>().text);

        option02.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        option02Image.sprite = items.m_eqippableItems[rand].displayImage;
        priceGet[1] = CheckPrice(currentWeapon, items.m_eqippableItems[rand]);
        temp2 = rand;

        do
        {
            rand = Random.Range(7, 13);
        }
        while (items.m_eqippableItems[rand].itemName == currentArmour.itemName);

        option03.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        option03Image.sprite = items.m_eqippableItems[rand].displayImage;
        priceGet[2] = CheckPrice(currentArmour, items.m_eqippableItems[rand]);
        temp3 = rand;

        do
        {
            rand = Random.Range(7, 13);
        }
        while (items.m_eqippableItems[rand].itemName == currentArmour.itemName || items.m_eqippableItems[rand].itemName == option03.GetComponentInChildren<Text>().text);

        option04.GetComponentInChildren<Text>().text = items.m_eqippableItems[rand].itemName;
        option04Image.sprite = items.m_eqippableItems[rand].displayImage;
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
        Debug.Log(money);
        FindObjectOfType<ItemAlpha>().SendCoins(money);
        GetCoins();
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
            FindObjectOfType<ItemAlpha>().CurrentWeapon(weaponNum);
            selectedWeapon = true;
        }

        else if (selected == 2)
        {
            items.m_eqippableItems[weaponNum].equipped = false;
            items.m_eqippableItems[temp2].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentWeapon.cost - items.m_eqippableItems[temp2].cost);
            currentWeapon = items.m_eqippableItems[temp2];
            weaponNum = temp2;
            FindObjectOfType<ItemAlpha>().CurrentWeapon(weaponNum);
            selectedWeapon = true;
        }

        else if (selected == 3)
        {
            items.m_eqippableItems[armourNum].equipped = false;
            items.m_eqippableItems[temp3].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentArmour.cost - items.m_eqippableItems[temp3].cost);
            currentArmour = items.m_eqippableItems[temp3];
            armourNum = temp3;
            FindObjectOfType<ItemAlpha>().CurrentArmour(armourNum);
            selectedArmour = true;
        }

        else if (selected == 4)
        {
            items.m_eqippableItems[armourNum].equipped = false;
            items.m_eqippableItems[temp4].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentArmour.cost - items.m_eqippableItems[temp4].cost);
            currentArmour = items.m_eqippableItems[temp4];
            armourNum = temp4;
            FindObjectOfType<ItemAlpha>().CurrentArmour(armourNum);
            selectedArmour = true;
        }

        else
        {
            items.m_useableItems[backpackNum].equipped = false;
            items.m_useableItems[temp5].equipped = true;
            FindObjectOfType<ItemAlpha>().SendCoins(currentBackpack.cost - items.m_useableItems[temp5].cost);
            currentBackpack = items.m_useableItems[temp5];
            backpackNum = temp5;
            FindObjectOfType<ItemAlpha>().CurrentBackpack(backpackNum);
            selectedBackpack = true;
            option05.interactable = false;
        }

        UpdateInventoryDisplay();
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

    public void UpdateInventoryDisplay()
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

    public void NewTown()
    {
        SellAllJunk();
        GetCoins();
        UpdateInventoryDisplay();
        DisplayWares();
    }

    public void Check()
    {
        Debug.Log(weaponNum);
        Debug.Log(armourNum);
        Debug.Log(backpackNum);
    }
}
