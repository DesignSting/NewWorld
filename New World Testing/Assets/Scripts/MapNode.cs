using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    public bool isFirst;
    public bool isLast;
    public Button[] next;

    public void Start()
    {
        if(!isFirst)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void DisplayNextStep()
    {
        for(int i = 0; i < next.Length; i++)
        {
            next[i].interactable = true;
        }
    }
}
