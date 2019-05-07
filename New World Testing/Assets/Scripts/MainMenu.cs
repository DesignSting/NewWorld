using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button newGame;
    public Button information;
    public Button exitGame;


    public GameObject mapTest;
    public GameObject inventoryPanel;
    public GameObject storePanel;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void NewGame()
    {
        inventoryPanel.SetActive(true);
        //inventoryPanel.GetComponent<DisplayPanel>().ShowPanel();
        inventoryPanel.GetComponent<DisplayPanel>().HideButtons();
        storePanel.SetActive(true);
        //storePanel.GetComponent<DisplayPanel>().ShowPanel();
        //storePanel.GetComponent<DisplayPanel>().HideButtons();

        //FindObjectOfType<InventoryDisplay>().UpdateItemsDisplay();
        //FindObjectOfType<StoreFront>().DisplayWares();
        //FindObjectOfType<InventoryDisplay>().UpdateEquippedItems();

    }

    public void StartGame()
    {
        inventoryPanel.GetComponent<DisplayPanel>().ShowPanel();
    }

    public void Information()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
