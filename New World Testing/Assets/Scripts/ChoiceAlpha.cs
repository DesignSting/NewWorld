using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceAlpha : MonoBehaviour {

    public static ChoiceAlpha Instance = null;

    public Button button1;
    public Button button2;
    public Button button3;

    [TextArea(3,6)]
    public string choiceTitle;
    public Text buttonTitle;
    public Text textBox;

    public List<ChoiceList> m_ChoiceList = new List<ChoiceList>();


    void Awake()
    {
        Instance = this;
    }

    public void ChangeButtonTitle()
    {
        buttonTitle.text = choiceTitle;
        //buttonTitle.resizeTextForBestFit = true;
    }

    public void DisplayText()
    {
        int rand = Random.Range(0, m_ChoiceList.Capacity);
        Debug.Log(rand);
        FindObjectOfType<ResultDisplay>().AcceptChoice(m_ChoiceList[rand], GetComponentInParent<Destination>().destinationPanel);

    }

    
}
