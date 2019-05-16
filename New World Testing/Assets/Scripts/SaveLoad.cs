using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {

    public ItemAlpha items;

    private int currentWeapon;
    private int currentArmour;
    private int currentBackpack;
    private int currentCoins;
    private int currentHealth;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveGame(int saveSlot)
    {
        //Since they can only save and quit at towns there will be no need to count all the items. Just need to make sure
        //That the health, money and the equipped items are correct. As well as what map number they are up to.
        EnterTown();

        PlayerPrefs.SetInt("currentWeapon_CharSlot" + saveSlot, currentWeapon);
        PlayerPrefs.SetInt("currentArmour_CharSlot" + saveSlot, currentArmour);
        PlayerPrefs.SetInt("currentBackpack_CharSlot" + saveSlot, currentBackpack);
        PlayerPrefs.SetInt("currentCoins_CharSlot" + saveSlot, currentCoins);
        PlayerPrefs.SetInt("currentHealth_CharSlot" + saveSlot, currentHealth);
    }

    public void LoadGame(int saveSlot)
    {
        currentWeapon = PlayerPrefs.GetInt("currentWeapon_CharSlot" + saveSlot);
        currentArmour = PlayerPrefs.GetInt("currentArmour_CharSlot" + saveSlot);
        currentBackpack = PlayerPrefs.GetInt("currentBackpack_CharSlot" + saveSlot);
        currentCoins = PlayerPrefs.GetInt("currentCoins_CharSlot" + saveSlot);
        currentHealth = PlayerPrefs.GetInt("currentHealth_CharSlot" + saveSlot);

        items.LoadSaveGame(currentWeapon,currentArmour,currentBackpack,currentCoins,currentHealth);
        GetComponent<MainMenu>().LoadGame();
        //GetComponent<MainMenu>().NewTown();
        
    }

    public void EnterTown()
    {
        currentWeapon = items.CurrentWeaponNum();
        currentArmour = items.CurrentArmourNum();
        currentBackpack = items.CurrentBackpackNum();
        currentCoins = items.ReturnCoins();
        currentHealth = items.CurrentHealth();
    }
}
