using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject currentActivePanel; 
    public GameObject currentActiveTab;
    public Button LevelsButton;
    public Button AchievmentsButton;
    public Button MultiplayerButton;

    public void Start()
    {
        currentActivePanel = GameObject.FindGameObjectWithTag("CompanyPanel"); //��� �������� ���������� ��������� ������� ������ ����� ������ � ����������
        currentActiveTab = GameObject.FindGameObjectWithTag("LevelsButton");
        currentActivePanel.SetActive(true);
    }

    public void ChangeTab(GameObject openningPanel) // ������� ��� ����� ���� ������ ���������
    {
        OpenPanel(openningPanel);
        if(openningPanel.name == "LevelsPanel")
        {

        }
    }
    public void OpenPanel(GameObject openningPanel) // ������� ��� ����� ������
    {
        currentActivePanel.SetActive(false);
        currentActivePanel = openningPanel;
        currentActivePanel.SetActive(true);
    }
    
    
}
