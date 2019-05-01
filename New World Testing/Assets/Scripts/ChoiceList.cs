using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ChoiceList
{

    public string name;                 // Inspector Element Name

    [TextArea(5,10)]                    // Makes the text box to the player 
    public string textToDisplay;        // What is shown to the player to continue the story

    public bool badChoice;              // Returns true if this was a bad choice
    public string[] protectiveItems;    // Lists the names of the items that protects the player in a 'bad choice'
    public bool tookDamage;             // bool too state if damage is taken
    public int[] damageTaken;             // int value of the damage taken by the player

    public List<LootList> loot = new List<LootList>();
    public List<LootList> lootTaken = new List<LootList>();

    public ChoiceList(string newName, string newTextBox, bool newBadChoice, string[] newProtectiveItems, bool newTookDamage, int[] newDamageTaken)
    {
        name = newName;
        textToDisplay = newTextBox;
        badChoice = newBadChoice;
        protectiveItems = newProtectiveItems;
        tookDamage = newTookDamage;
        damageTaken = newDamageTaken;
    }

    public string ReturnText()
    {
        return textToDisplay;
    }

}
