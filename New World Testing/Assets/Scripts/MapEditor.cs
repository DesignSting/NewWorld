using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapEditor : MonoBehaviour {

    public Button[] wasteland;
    public Button[] river;
    public Button[] ford;
    public Button[] cliff;
    public Button[] other;

    private bool hasRiver;
    private bool hasCliff;
    public Destination wastelandScript;
    public Destination hillScript;
    public Destination abandonedScript;
    public Destination mountainScript;
    public Destination woodedScript;

    public Destination cliffScript;
    public Destination riverScript;
    public Destination fordScript;



	// Use this for initialization
	void Start ()
    {
        hasRiver = (river.Length != 0);
        hasCliff = (cliff.Length != 0);

        SetUpMap();
        for (int i = 0; i <wasteland.Length; i++)
        {
            
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SetUpMap()
    {
        int rand = Random.Range(0, 3);
        for (int i = 0; i < wasteland.Length; i++)
        {
            wasteland[i].GetComponentInChildren<Destination>().destinationName = wastelandScript.destinationName;
            wasteland[i].GetComponentInChildren<Destination>().uncovered = wastelandScript.uncovered;
            wasteland[i].GetComponentInChildren<Destination>().covered = wastelandScript.covered;
            wasteland[i].GetComponentInChildren<Destination>().destinationPanel = wastelandScript.destinationPanel;
            wasteland[i].GetComponentInChildren<Destination>().headline = wastelandScript.headline;
            wasteland[i].GetComponentInChildren<Destination>().choice1 = wastelandScript.choice1;
            wasteland[i].GetComponentInChildren<Destination>().choice2 = wastelandScript.choice2;
            wasteland[i].GetComponentInChildren<Destination>().choice3 = wastelandScript.choice3;

            wasteland[i].GetComponentInChildren<Text>().text = wastelandScript.destinationName;
        }

        for (int i = 0; i < other.Length; i++)
        {
            if(rand == 0)
            {
                other[i].GetComponentInChildren<Destination>().destinationName = hillScript.destinationName;
                other[i].GetComponentInChildren<Destination>().uncovered = hillScript.uncovered;
                other[i].GetComponentInChildren<Destination>().covered = hillScript.covered;
                other[i].GetComponentInChildren<Destination>().destinationPanel = hillScript.destinationPanel;
                other[i].GetComponentInChildren<Destination>().headline = hillScript.headline;
                other[i].GetComponentInChildren<Destination>().choice1 = hillScript.choice1;
                other[i].GetComponentInChildren<Destination>().choice2 = hillScript.choice2;
                other[i].GetComponentInChildren<Destination>().choice3 = hillScript.choice3;

                other[i].GetComponentInChildren<Text>().text = hillScript.destinationName;
            }

            if (rand == 1)
            {
                other[i].GetComponentInChildren<Destination>().destinationName = abandonedScript.destinationName;
                other[i].GetComponentInChildren<Destination>().uncovered = abandonedScript.uncovered;
                other[i].GetComponentInChildren<Destination>().covered = abandonedScript.covered;
                other[i].GetComponentInChildren<Destination>().destinationPanel = abandonedScript.destinationPanel;
                other[i].GetComponentInChildren<Destination>().headline = abandonedScript.headline;
                other[i].GetComponentInChildren<Destination>().choice1 = abandonedScript.choice1;
                other[i].GetComponentInChildren<Destination>().choice2 = abandonedScript.choice2;
                other[i].GetComponentInChildren<Destination>().choice3 = abandonedScript.choice3;

                other[i].GetComponentInChildren<Text>().text = abandonedScript.destinationName;
            }

            if (rand == 2)
            {
                other[i].GetComponentInChildren<Destination>().destinationName = mountainScript.destinationName;
                other[i].GetComponentInChildren<Destination>().uncovered = mountainScript.uncovered;
                other[i].GetComponentInChildren<Destination>().covered = mountainScript.covered;
                other[i].GetComponentInChildren<Destination>().destinationPanel = mountainScript.destinationPanel;
                other[i].GetComponentInChildren<Destination>().headline = mountainScript.headline;
                other[i].GetComponentInChildren<Destination>().choice1 = mountainScript.choice1;
                other[i].GetComponentInChildren<Destination>().choice2 = mountainScript.choice2;
                other[i].GetComponentInChildren<Destination>().choice3 = mountainScript.choice3;

                other[i].GetComponentInChildren<Text>().text = mountainScript.destinationName;
            }

            if (rand == 3)
            {
                other[i].GetComponentInChildren<Destination>().destinationName = woodedScript.destinationName;
                other[i].GetComponentInChildren<Destination>().uncovered = woodedScript.uncovered;
                other[i].GetComponentInChildren<Destination>().covered = woodedScript.covered;
                other[i].GetComponentInChildren<Destination>().destinationPanel = woodedScript.destinationPanel;
                other[i].GetComponentInChildren<Destination>().headline = woodedScript.headline;
                other[i].GetComponentInChildren<Destination>().choice1 = woodedScript.choice1;
                other[i].GetComponentInChildren<Destination>().choice2 = woodedScript.choice2;
                other[i].GetComponentInChildren<Destination>().choice3 = woodedScript.choice3;

                other[i].GetComponentInChildren<Text>().text = woodedScript.destinationName;
            }

            rand = Random.Range(0, 3);
        }

        if(hasRiver)
        {
            for (int i = 0; i < river.Length; i++)
            {
                river[i].GetComponentInChildren<Destination>().destinationName = riverScript.destinationName;
                river[i].GetComponentInChildren<Destination>().uncovered = riverScript.uncovered;
                river[i].GetComponentInChildren<Destination>().covered = riverScript.covered;
                river[i].GetComponentInChildren<Destination>().destinationPanel = riverScript.destinationPanel;
                river[i].GetComponentInChildren<Destination>().headline = riverScript.headline;
                river[i].GetComponentInChildren<Destination>().choice1 = riverScript.choice1;
                river[i].GetComponentInChildren<Destination>().choice2 = riverScript.choice2;
                river[i].GetComponentInChildren<Destination>().choice3 = riverScript.choice3;

                river[i].GetComponentInChildren<Text>().text = riverScript.destinationName;
            }

            for (int i = 0; i < ford.Length; i++)
            {
                ford[i].GetComponentInChildren<Destination>().destinationName = fordScript.destinationName;
                ford[i].GetComponentInChildren<Destination>().uncovered = fordScript.uncovered;
                ford[i].GetComponentInChildren<Destination>().covered = fordScript.covered;
                ford[i].GetComponentInChildren<Destination>().destinationPanel = fordScript.destinationPanel;
                ford[i].GetComponentInChildren<Destination>().headline = fordScript.headline;
                ford[i].GetComponentInChildren<Destination>().choice1 = fordScript.choice1;
                ford[i].GetComponentInChildren<Destination>().choice2 = fordScript.choice2;
                ford[i].GetComponentInChildren<Destination>().choice3 = fordScript.choice3;

                ford[i].GetComponentInChildren<Text>().text = fordScript.destinationName;
            }
        }

        if(hasCliff)
        {
            for (int i = 0; i < cliff.Length; i++)
            {
                cliff[i].GetComponentInChildren<Destination>().destinationName = cliffScript.destinationName;
                cliff[i].GetComponentInChildren<Destination>().uncovered = cliffScript.uncovered;
                cliff[i].GetComponentInChildren<Destination>().covered = cliffScript.covered;
                cliff[i].GetComponentInChildren<Destination>().destinationPanel = cliffScript.destinationPanel;
                cliff[i].GetComponentInChildren<Destination>().headline = cliffScript.headline;
                cliff[i].GetComponentInChildren<Destination>().choice1 = cliffScript.choice1;
                cliff[i].GetComponentInChildren<Destination>().choice2 = cliffScript.choice2;
                cliff[i].GetComponentInChildren<Destination>().choice3 = cliffScript.choice3;

                cliff[i].GetComponentInChildren<Text>().text = cliffScript.destinationName;
            }
        }
    }

    public void PossiblePath(Button currentLocation)
    {
        for (int i = 0; i < cliff.Length; i++)
        {
            string thisName = "";
            thisName = currentLocation.GetComponent<MapNode>().next[i].GetComponent<Destination>().destinationName;
            Debug.Log(thisName);
        }
    }
}
