using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPanel : MonoBehaviour {

    public Animator animator;

    public void Start()
    {
        animator.SetBool("isOpen", true);
    }

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
}
