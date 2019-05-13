using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour {

    public string destinationName;
    public Sprite uncovered;
    public Sprite covered;
    public Image test;

    public GameObject destinationPanel;

    public GameObject headline;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;

    public Button thisButton;
    public Button[] possibleNext;


    public void SetUp()
    {
        if(!GetComponent<MapNode>().isFirst)
        {
            FindObjectOfType<ResultDisplay>().HideOldButton(true);
        }
        FindObjectOfType<ResultDisplay>().ResetPanel();
        FindObjectOfType<MapEditor>().HideMap();
        headline.GetComponentInChildren<Text>().text = destinationName;
        destinationPanel.SetActive(true);


        choice1.GetComponentInChildren<Text>().text = choice1.GetComponent<ChoiceAlpha>().choiceTitle;
        choice2.GetComponentInChildren<Text>().text = choice2.GetComponent<ChoiceAlpha>().choiceTitle;
        choice3.GetComponentInChildren<Text>().text = choice3.GetComponent<ChoiceAlpha>().choiceTitle;

        FindObjectOfType<ResultDisplay>().LastClicked(GetComponent<Button>());
        //Cloud();
    }

    public void Cloud()
    {
        if(thisButton.interactable == false)
        {
            thisButton.image = test;
        }
    }

    public void Mask()
    {
        
    }
}
