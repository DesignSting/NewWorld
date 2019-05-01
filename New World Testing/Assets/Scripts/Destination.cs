using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour {

    public string destinationName;
    public Sprite uncovered;
    public Sprite covered;

    public GameObject destinationPanel;

    public GameObject headline;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;


    public void SetUp()
    {
        headline.GetComponentInChildren<Text>().text = destinationName;
        destinationPanel.SetActive(true);

        choice1.GetComponentInChildren<Text>().text = choice1.GetComponent<ChoiceAlpha>().choiceTitle;
        choice2.GetComponentInChildren<Text>().text = choice2.GetComponent<ChoiceAlpha>().choiceTitle;
        choice3.GetComponentInChildren<Text>().text = choice3.GetComponent<ChoiceAlpha>().choiceTitle;
    }

    public void ResetCanvas()
    {
        FindObjectOfType<ResultDisplay>().resultPanel.SetActive(false);
        SetUp();
    }

}
