﻿using System.Collections;
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

    public int multiDirection;          // 0 = North, 1 = ReqRope, 2 = South
    public List<ChoiceList> m_ChoiceList = new List<ChoiceList>();


    public void Start()
    {
        if(multiDirection == 1)
        {
            if(FindObjectOfType<ItemAlpha>().ReturnRope() == 0)
            {
                GetComponent<Button>().interactable = false;
            }
        }
    }
    /*
    void Awake()
    {
        Instance = this;
    }
    */
    public void ChangeButtonTitle()
    {
        buttonTitle.text = choiceTitle;
    }

    public void DisplayText()
    {
        int rand = Random.Range(0, m_ChoiceList.Capacity);
        FindObjectOfType<ResultDisplay>().AcceptChoice(m_ChoiceList[rand], GetComponentInParent<Destination>().destinationPanel);

    }

    
}
