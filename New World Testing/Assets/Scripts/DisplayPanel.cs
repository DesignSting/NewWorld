using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPanel : MonoBehaviour {

    public Animator animator;
    public Button buttonIn;
    public Button buttonOut;
    /*
    public void Start()
    {
        animator.SetBool("isOpen", true);
    }
    */
    public void IsClicked()
    {
        bool state = animator.GetBool("isOpen");
        if(state)
        {
            animator.SetBool("isOpen", false);
        }
        else
            animator.SetBool("isOpen", true);
    }

    public void ShowPanel()
    {
        animator.SetBool("isGame", true);

    }

    public void HidePanel()
    {

    }

    public void ShowButtons()
    {
        
    }

    public void HideButtons()
    {
        Debug.Log(buttonOut.gameObject.name);
        buttonIn.gameObject.SetActive(false);
        buttonOut.gameObject.SetActive(false);
    }
}
