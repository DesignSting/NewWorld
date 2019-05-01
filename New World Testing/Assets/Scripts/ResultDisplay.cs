using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultDisplay : MonoBehaviour {

    public GameObject resultPanel;
    public Text storyBox;
    public Text positiveBox;
    public Text negativeBox;
    public Text lootBox;

    public Button nextButton;


    public void AcceptChoice(ChoiceList choice, GameObject panel)
    {
        panel.SetActive(false);
        resultPanel.SetActive(true);
        storyBox.text = choice.textToDisplay;

    }
}
