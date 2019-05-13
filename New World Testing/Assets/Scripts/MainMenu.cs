using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mapTest;
    public GameObject inventoryPanel;
    public GameObject townScreenPanel;
    public GameObject mainMenuPanel;


    public void NewGame()
    {
        FindObjectOfType<ItemAlpha>().CheckEquipped();
        FindObjectOfType<ItemAlpha>().NewGame();
        mainMenuPanel.SetActive(false);
        townScreenPanel.SetActive(true);
    }

    public void StartGame()
    {
        townScreenPanel.SetActive(false);
        mapTest.SetActive(true);
        inventoryPanel.SetActive(true);
        FindObjectOfType<InventoryDisplay>().UpdateEquippedItems();
        FindObjectOfType<InventoryDisplay>().UpdateItemsDisplay();
        FindObjectOfType<MapEditor>().SetUpMap();
    }

    public void Information()
    {
        Debug.Log("This is the information button");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("This is the quit button");
    }

    public void MainMenuReturn()
    {
        mapTest.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void NewTown()
    {
        mapTest.SetActive(false);
        townScreenPanel.SetActive(true);
        inventoryPanel.SetActive(false);
        FindObjectOfType<StoreFront>().NewTown();
        GetComponent<SaveLoad>().SaveGame(0);
    }

    public void LoadGame()
    {
        mainMenuPanel.SetActive(false);
        townScreenPanel.SetActive(true);
    }
}
