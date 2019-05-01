using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour {

    public GameObject resultPanel;
    public Text storyBox;
    public Text positiveBox;
    public Text negativeBox;
    public Text lootBox;

    public Button lastClicked;
    public Button nextButton;
    public ItemAlpha items;

    public GameObject map;

    public int currentHealth;


    public void AcceptChoice(ChoiceList choice, GameObject panel)
    {
        panel.SetActive(false);
        storyBox.text = choice.textToDisplay;
        if (choice.badChoice)
        {
            BadResult(choice);
        }

        else
        {
            GoodResult(choice);
        }

        resultPanel.SetActive(true);
        

    }

    private void GoodResult(ChoiceList choice)
    {
        if (choice.loot.Capacity != 0)
        {
            positiveBox.text = "You recieved ";
            for (int i = 0; i < choice.loot.Capacity; i++)
            {
                positiveBox.text += choice.loot[i].amount + " " + choice.loot[i].name;
                FindObjectOfType<ItemAlpha>().UpdateInventory(choice.loot[i].name, choice.loot[i].amount);
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
        else
            positiveBox.text = "Sadly you recieved no loot";
    }
    private void BadResult(ChoiceList choice)
    {
        if (CheckDefences(choice.protectiveItems))
        {
            if (currentHealth - choice.damageTaken[1] <= 0 && choice.tookDamage)
            {
                storyBox.text = "You have died!";
            }
            else
            {
                negativeBox.text = "";
                negativeBox.text = "You took " + choice.damageTaken[1].ToString() + " because you had one of these items ";
                for (int i = 0; i < choice.protectiveItems.Length; i++)
                {
                    negativeBox.text += choice.protectiveItems[i];
                    if ((choice.protectiveItems.Length - i) == 1)
                    {
                        negativeBox.text += "!";
                    }
                    else
                        negativeBox.text += ", ";

                }
                GoodResult(choice);
            }

        }
        else
        {
            currentHealth -= choice.damageTaken[0];
            if (currentHealth < 0 && choice.tookDamage)
            {
                storyBox.text = "You have died!";
            }
            GoodResult(choice);

        }
    }

    private bool CheckDefences(string[] protect)
    {
        bool isDefended = false;
        for(int i = 0; i < protect.Length; i++)
        {
            for(int j = 0; j <items.m_eqippableItems.Capacity; j++)
            {
                if((protect[i] == items.m_eqippableItems[j].itemName) && items.m_eqippableItems[j].equipped)
                {
                    isDefended = true;
                    break;
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

}
