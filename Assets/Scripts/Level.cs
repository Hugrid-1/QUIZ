using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    public Question[] levelQuestionsData;
    public void LoadLevel()
    {
        Debug.Log("Загрузка вопросов");
        GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().filteredQuestions = levelQuestionsData;
        SceneManager.LoadScene("TestLevel", LoadSceneMode.Additive);
    }
}
