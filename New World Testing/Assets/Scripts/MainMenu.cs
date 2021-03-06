﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject currentMap;
    public GameObject inventoryPanel;
    public GameObject townScreenPanel;
    public GameObject mainMenuPanel;


    public GameObject pausePanel;
    public float timer;
    public bool isTiming;

    private void Update()
    {
        if(isTiming)
        {
            timer += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentMap.activeInHierarchy)
            {
                isTiming = true;
                pausePanel.SetActive(true);
                currentMap.SetActive(false);
            }
            if (pausePanel.activeInHierarchy & timer > 0.2)
            {
                pausePanel.SetActive(false);
                currentMap.SetActive(true);
                timer = 0;
                isTiming = false;
            }
        }

    }
    public void NewGame()
    {
        FindObjectOfType<ItemAlpha>().CheckEquipped();
        FindObjectOfType<ItemAlpha>().NewGame();
        mainMenuPanel.SetActive(false);
        townScreenPanel.SetActive(true);
        FindObjectOfType<StoreFront>().SendToDisplay();
        FindObjectOfType<InventoryDisplay>().ResetExpectedCoins();
        FindObjectOfType<InventoryDisplay>().UpdateItemsDisplay();
    }

    public void StartGame()
    {
        townScreenPanel.SetActive(false);
        currentMap.SetActive(true);
        inventoryPanel.SetActive(true);
        FindObjectOfType<StoreFront>().SendToDisplay();
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
        currentMap.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void NewTown(GameObject nextMap)
    {

        currentMap.SetActive(false);
        currentMap = nextMap;
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
        currentMap.SetActive(false);
        inventoryPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ShowMap()
    {
        currentMap.SetActive(true);
    }

    public void PauseMenu()
    {
        Debug.Log("THis is the pause menu");
    }

    public void BackButton()
    {

    }
}
