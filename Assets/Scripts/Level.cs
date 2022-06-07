using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Level : MonoBehaviour
{
    public Question[] levelQuestionsData;
    public bool onTime = false;

    public void LoadLevel()
    {
        Debug.Log("Загрузка вопросов");
        GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().filteredQuestions = levelQuestionsData;
        GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().level = this;
        SceneManager.LoadScene("TestLevel", LoadSceneMode.Additive);
    }
}
