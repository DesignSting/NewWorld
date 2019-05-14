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

    private int currentHealth;

    public Button choice1;
    public Button choice2;
    private bool isChoice;
    private int choiceMade;
    //private bool isTimer;
    public float timer;

    private void Update()
    {
        if(timer > 5)
        {
            isChoice = true;
            choiceMade = 1;
            timer = 0;
            //isTimer = false;
        }
    }


    public void AcceptChoice(ChoiceList choice, GameObject panel)
    {
        ResetPanel();
        panel.SetActive(false);
        storyBox.text = choice.textToDisplay;
        resultPanel.SetActive(true);
        currentHealth = items.CurrentHealth();
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
                    items.SendCoins(choice.loot[i].amount);
                }
                else
                {
                    positiveBox.text += choice.loot[i].amount + " " + choice.loot[i].name;
                    items.UpdateItems(choice.loot[i].name, choice.loot[i].amount);
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
        Debug.Log("Creature " + choice.creatureDamage + " & Bait " + items.ReturnBait());
        choiceMade = 1;
        //if((choice.creatureDamage) && (items.ReturnBait() > 0))
        //{
        //    encounterBox.enabled = true;
        //    encounterBox.text = "Would you use one of your baits? Or just attack?!?";
        //    positiveBox.text = "You only have " + currentHealth + "hp left!";
        //    choice1.gameObject.SetActive(true);
        //    choice2.gameObject.SetActive(true);
        //    //isTimer = true;

        //    do
        //    {
        //        timer += Time.deltaTime;
        //    }
        //    while (!isChoice);
        //    isChoice = false;
        //    //isTimer = false;
        //    timer = 0;
        //    choice1.gameObject.SetActive(false);
        //    choice2.gameObject.SetActive(false);
        //}
        if (choiceMade == 1)
        {
            int dmgTaken = 0;
            if (choice.damageTaken.Length > 1)
                negativeBox.text = "You took " + choice.damageTaken[1].ToString() + " DMG because you had ";
            if (CheckDefences(choice.protectiveItems))
            {
                if (currentHealth - choice.damageTaken[1] <= 0 && choice.tookDamage)
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
                    negativeBox.text += " eqipped";
                    currentHealth -= choice.damageTaken[1];
                    dmgTaken = choice.damageTaken[1];
                    GoodResult(choice);
                }

            }
            else
            {
                if (choice.tookDamage)
                {
                    currentHealth -= choice.damageTaken[0];
                    dmgTaken = choice.damageTaken[0];
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

            if (choice.lootLost.Capacity > 0)
            {
                if (choice.lootLost[0].name == "All")
                {
                    for (int i = 0; i < choice.lootLost.Capacity; i++)
                    {
                        items.EmptyItem(choice.lootLost[i].name);
                    }
                }
                lootBox.text = "You have lost ";
                for (int i = 0; i < choice.lootLost.Capacity; i++)
                {
                    items.RemoveItem(choice.lootLost[i].name, choice.lootLost[i].amount);
                    lootBox.text += choice.lootLost[i].amount + " " + choice.lootLost[i].name;
                    if (choice.lootLost.Capacity - i == 1)
                    {
                        lootBox.text += "!";
                    }
                    else
                        lootBox.text += ", ";
                }
            }
            items.CurrentHealth(-dmgTaken);
        }

        if(choiceMade == 2)
        {
            encounterBox.text = "";
            storyBox.text = "Throwing the meat to the savaged your quickly make your escape while they fight over the food. /n Nice Move";
            items.RemoveItem("Bait", -1);
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
                if (isDefended)
                    break;
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
        if (lastClicked.GetComponent<MapNode>().isLast)
        {
            FindObjectOfType<MainMenu>().NewTown();
        }
        else
        {
            Button[] next = null;
            next = lastClicked.GetComponentInChildren<Destination>().possibleNext;
            if (!clicked)
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

    public void AfterDeath()
    {
        ResetPanel();
        deathPanel.SetActive(false);
        resultPanel.SetActive(false);
    }

    public void ButtonChoice(int i)
    {
        choiceMade = i;
        isChoice = true;
    }
    /**
     *  - Need to get the bait system working
                - Maybe take it out just after the choice goes to result and wait for user input there
                - Make the original BadResult take an int as well to make sure they are not being confused
        - Move the items to the top of the screen and always visible while on map screen
        - Start populating more maps and figure out how they are going to connect to one another. This means the player can always go the wrong way and end up in bad areas. Also will mean they will need to change weapons and armour more often
        - Have the HP, Expected gold and medipacs at the bottom of the screen?
     * 
     * */

}
