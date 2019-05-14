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
    public bool creatureDamage;         // True if a creature was involved in your damage
    public int[] damageTaken;           // int value of the damage taken by the player
    [TextArea(1,3)]
    public string encounterResult;
    [TextArea(1,3)]
    public string deathMessage;

    public List<LootList> loot = new List<LootList>();
    public List<LootList> lootLost = new List<LootList>();



    public ChoiceList(string newName, string newTextBox, bool newBadChoice, string[] newProtectiveItems, bool newTookDamage, bool newCreatureDamage, int[] newDamageTaken, string newDeathMessage)
    {
        name = newName;
        textToDisplay = newTextBox;
        badChoice = newBadChoice;
        protectiveItems = newProtectiveItems;
        tookDamage = newTookDamage;
        creatureDamage = newCreatureDamage;
        damageTaken = newDamageTaken;
        deathMessage = newDeathMessage;
    }

    public string ReturnText()
    {
        return textToDisplay;
    }

}
