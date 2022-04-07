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
        currentActivePanel = GameObject.FindGameObjectWithTag("CompanyPanel"); //при загрузке приложения стартовой панелью всегда будет панель с компаниями
        currentActiveTab = GameObject.FindGameObjectWithTag("LevelsButton");
        currentActivePanel.SetActive(true);
    }

    public void ChangeTab(GameObject openningPanel) // Функция для смены вида кнопок навигации
    {
        OpenPanel(openningPanel);
        if(openningPanel.name == "LevelsPanel")
        {

        }
    }
    public void OpenPanel(GameObject openningPanel) // Функция для смены панели
    {
        currentActivePanel.SetActive(false);
        currentActivePanel = openningPanel;
        currentActivePanel.SetActive(true);
    }
    
    
}
