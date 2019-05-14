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

    //public float timer;
    //public bool mouseOver;

    //private void Update()
    //{
    //    if (inventoryPanel.activeInHierarchy)
    //    {
    //        if (inventoryPanel.GetComponent<Animator>().GetBool("isOpen"))
    //        {
    //            timer += Time.deltaTime;
    //        }
    //        if (timer > 3 && !mouseOver)
    //        {
    //            inventoryPanel.GetComponent<Animator>().SetBool("isOpen", false);
    //            timer = 0;
    //        }
    //    }

    //}

    public void NewGame()
    {
        FindObjectOfType<ItemAlpha>().CheckEquipped();
        FindObjectOfType<ItemAlpha>().NewGame();
        //inventoryPanel.SetActive(true);
        //inventoryPanel.GetComponent<Animator>().SetBool("isOpen", true);
        mainMenuPanel.SetActive(false);
        townScreenPanel.SetActive(true);
        FindObjectOfType<StoreFront>().SendToDisplay();
        FindObjectOfType<InventoryDisplay>().ResetExpectedCoins();
        FindObjectOfType<InventoryDisplay>().UpdateItemsDisplay();
    }

    public void StartGame()
    {
        townScreenPanel.SetActive(false);
        mapTest.SetActive(true);
        inventoryPanel.SetActive(true);
        FindObjectOfType<StoreFront>().SendToDisplay();
        //FindObjectOfType<InventoryDisplay>().UpdateEquippedItems();
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
        inventoryPanel.GetComponent<Animator>().SetBool("isOpen", true);
        FindObjectOfType<StoreFront>().NewTown();
        GetComponent<SaveLoad>().SaveGame(0);
    }

    public void LoadGame()
    {
        mainMenuPanel.SetActive(false);
        townScreenPanel.SetActive(true);
    }

    public void ToMainMenu()
    {
        mapTest.SetActive(false);
        inventoryPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
