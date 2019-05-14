using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Animator animator;
    public Button buttonIn;
    public Button buttonOut;

    public float timer;
    public bool mouseOver;

    public Vector3 mouse = new Vector3();

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if(animator.GetBool("isOpen"))
            {
                timer += Time.deltaTime;
            }

            if(timer >3 && !mouseOver)
            {
                animator.SetBool("isOpen", false);
                timer = 0;
            }
        }
        mouse = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        timer = 0;
        //throw new System.NotImplementedException();
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

    public void ShowPanel()
    {
        animator.SetBool("isGame", true);

    }

    public void HideButtons()
    {
        Debug.Log(buttonOut.gameObject.name);
        buttonIn.gameObject.SetActive(false);
        buttonOut.gameObject.SetActive(false);
    }
}
