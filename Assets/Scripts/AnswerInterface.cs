using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class AnswerInterface : MonoBehaviour
{
    public GameObject[] AnswerButtons;
    void Start()
    {
        AnswerButtons = GameObject.FindGameObjectsWithTag("AnswerButton");
    }

    
    public void ChangeButtonColor()
    {
        foreach(GameObject btn in AnswerButtons)
        {
            btn.GetComponentInChildren<Image>().tintColor = Color.red;
        }
    } 
    public void ChangeButtonColorToDefault()
    {

    }
    public void DrawLoadingPanel()
    {

    }
}
