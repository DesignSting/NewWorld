using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour {

    public GameObject resultPanel;
    public Text storyBox;
    public Text encounterBox;
    public Text positiveBox;
    public Text negativeBox;
    public Text lootBox;

    public GameObject deathPanel;
    public Text deathStoryBox;
    public Text deathBox;

    public Button lastClicked;
    public Button nextButton;
    public ItemAlpha items;

    public GameObject map;

    public int currentHealth;


    public void AcceptChoice(ChoiceList choice, GameObject panel)
    {
        panel.SetActive(false);
        storyBox.text = choice.textToDisplay;
        resultPanel.SetActive(true);
        if (choice.badChoice)
        {
            BadResult(choice);
        }

        else
        {
            GoodResult(choice);
        }

        FindObjectOfType<InventoryDisplay>().UpdateItemsDisplay();
    }


    private void GoodResult(ChoiceList choice)
    {
        if (choice.loot.Capacity != 0)
        {
            positiveBox.text = "You recieved ";
            for (int i = 0; i < choice.loot.Capacity; i++)
            {
                if (choice.loot[i].name == "Coins" || choice.loot[i].name == "Gold")
                {
                    positiveBox.text += choice.loot[i].amount + " gold pieces";
                    FindObjectOfType<ItemAlpha>().AddCoins(choice.loot[i].amount);
                }
                else
                {
                    positiveBox.text += choice.loot[i].amount + " " + choice.loot[i].name;
                    FindObjectOfType<ItemAlpha>().UpdateItems(choice.loot[i].name, choice.loot[i].amount);
                    if ((choice.loot.Capacity - i == 1))
                    {
                        positiveBox.text += "!";
                    }
                    else
                    {
                        positiveBox.text += ", ";
                    }
                }
            }
        }
    }


    private void BadResult(ChoiceList choice)
    {
        if(choice.damageTaken.Length > 1)
            negativeBox.text = "You took " + choice.damageTaken[1].ToString() + " because you had ";
        if (CheckDefences(choice.protectiveItems))
        {
            if (currentHealth - choice.damageTaken[1] <= 0 && choice.tookDamage)
            {
                if (choice.deathMessage.Length > 0)
                {
                    Death(choice.textToDisplay ,choice.deathMessage);
                }
                else
                    Death(choice.textToDisplay, "The wounds have caught up to you. You have died!");
            }
            else
            {
                if(choice.encounterResult.Length > 0)
                    encounterBox.text = choice.encounterResult;
                negativeBox.text += " eqipped";
                GoodResult(choice);
            }

        }
        else
        {
            if (choice.tookDamage)
            {
                currentHealth -= choice.damageTaken[0];
                if (currentHealth <= 0)
                {
                    if (choice.deathMessage.Length > 0)
                    {
                        Death(choice.textToDisplay, choice.deathMessage);
                    }
                    else
                        Death(choice.textToDisplay, "The wounds have caught up to you. You have died!");
                }
                else
                {
                    if (choice.encounterResult.Length > 0)
                        encounterBox.text = choice.encounterResult;
                    negativeBox.text = "You took " + choice.damageTaken[0].ToString() + " damage";
                    GoodResult(choice);

                }
            }

        }

        if(choice.lootLost.Capacity > 0)
        {
            lootBox.text = "You have lost ";
            for(int i = 0; i < choice.lootLost.Capacity; i++)
            {
                FindObjectOfType<ItemAlpha>().RemoveItem(choice.lootLost[i].name, choice.lootLost[i].amount);
                lootBox.text += choice.lootLost[i].amount + " " + choice.lootLost[i].name;
                if (choice.lootLost.Capacity - i == 1)
                {
                    lootBox.text += "!";
                }
                else
                    lootBox.text += ", ";
            }
        }
    }

    private bool CheckDefences(string[] protect)
    {
        bool isDefended = false;
        if (protect.Length > 0)
        {
            for (int i = 0; i < protect.Length; i++)
            {
                for (int j = 0; j < items.m_eqippableItems.Capacity; j++)
                {
                    if ((protect[i] == items.m_eqippableItems[j].itemName) && items.m_eqippableItems[j].equipped)
                    {
                        negativeBox.text += protect[i];
                        isDefended = true;
                        break;
                    }
                }
            }
        }

        return isDefended;
    }

    public void HideResults()
    {
        resultPanel.SetActive(false);
    }

    public void LastClicked(Button button)
    {
        lastClicked = button;
    }

    public void HideOldButton(bool clicked)
    {
        Button[] next = null;
        next = lastClicked.GetComponentInChildren<Destination>().possibleNext;
        if(!clicked)
        {
            lastClicked.interactable = false;
            for (int i = 0; i < next.Length; i++)
            {
                next[i].interactable = true;
            }
        }
        else
        {
            for (int i = 0; i < next.Length; i++)
            {
                next[i].interactable = false;
            }
        }
        
    }

    private void Death(string deathStory,string deathString)
    {
        Debug.Log(deathString);
        resultPanel.SetActive(false);
        deathPanel.SetActive(true);
        deathStoryBox.text = deathStory;
        deathBox.text = deathString;
    }

    public void ResetPanel()
    {
        storyBox.text = "";
        encounterBox.text = "";
        positiveBox.text = "";
        negativeBox.text = "";
        lootBox.text = "";
    }
}
