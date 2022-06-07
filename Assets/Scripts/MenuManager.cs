using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

/// 
/// Данный скрипт осуществляет создание набора вопросов для свободной игры
/// 
/// 

public class MenuManager : MonoBehaviour
{
    public Question[] questionsData;
    public Question[] filteredQuestions;
    public Dropdown catergoryDropdownElement;
    [SerializeField] public Level level;
    //данные для фильтрация
    public List<Question.questionDificulity> dificulities = new List<Question.questionDificulity>();
    public Question.questionCategory category = new Question.questionCategory();
    public bool allCategoryFilter = true;

    public void Start()
    {
        level.onTime = false;
        level.levelQuestionsData = questionsData;
    }
    public void StartFreeGame()
    {
        FilterQuestionList(); //Вызов функции для фильтрации списка вопросов
        level.levelQuestionsData = filteredQuestions;

        Debug.Log("Загрузка сцены TestLevel");
        SceneManager.LoadScene("TestLevel", LoadSceneMode.Additive);

    }

    private void FilterQuestionList()
    {
        Debug.Log("Фильтрация вопросов...");
        List<Question> filteredQuestionsList = new List<Question>();
        if (dificulities.Count == 0) //Если нет выбранной сложности то выбираются легкие
        {
            dificulities.Add(Question.questionDificulity.Easy);
        }
        if (allCategoryFilter) //проверка на наличие фильтра по всем категориям вопросов !КОСТЫЛЬ!
        {
            foreach (var question in questionsData)
            {
                Debug.Log(question.dificulity);
                Debug.Log(dificulities.Contains(question.dificulity));
                if (dificulities.Contains(question.dificulity)) //проверка на то является ли вопрос необходимой категории и сложности
                {
                    filteredQuestionsList.Add(question);
                }
            }
            Debug.Log("Вопросы отфильтрованы. Настройки : Сложность - " + dificulities + " Категория - " + category);

        }
        else
        {
            foreach (var question in questionsData)
            {
                Debug.Log(question.dificulity);

                if (question.category == category && dificulities.Contains(question.dificulity)) //проверка на то является ли вопрос необходимой категории и сложности
                {
                    filteredQuestionsList.Add(question);
                }
            }
            Debug.Log("Вопросы отфильтрованы. Настройки : Сложность - " + dificulities + " Все категории");

        }

        filteredQuestions = filteredQuestionsList.ToArray();
    }

    public void ChangeQuestionCategory(int value)
    {
        switch (value)
        {
            case 0:
                allCategoryFilter = true;
                break;
            case 1:
                Debug.Log("Категория вопросов - география");
                category = Question.questionCategory.Geography;
                allCategoryFilter = false;
                break;
            case 2:
                Debug.Log("Категория вопросов - история");
                category = Question.questionCategory.History;
                allCategoryFilter = false;
                break;
            case 3:
                Debug.Log("Категория вопросов - музыка");
                category = Question.questionCategory.Music;
                allCategoryFilter = false;
                break;
            case 4:
                Debug.Log("Категория вопросов - игры");
                category = Question.questionCategory.Games;
                allCategoryFilter = false;
                break;
        }
    }
    
    public void ChangeEasyDifficulity(bool value)
    {
        Question.questionDificulity dificulity = Question.questionDificulity.Easy;
        ChangeDifficulityList(value,dificulity);
    }
    public void ChangeMediumDifficulity(bool value)
    {
        Question.questionDificulity dificulity = Question.questionDificulity.Medium;
        ChangeDifficulityList(value, dificulity);
    }
    public void ChangeHardDifficulity(bool value)
    {
        Question.questionDificulity dificulity = Question.questionDificulity.Hard;
        ChangeDifficulityList(value, dificulity);
    }

    private void ChangeDifficulityList(bool value, Question.questionDificulity dificulity)
    {
        if (value == true)
        {
            dificulities.Add(dificulity);
        }
        else
        {
            dificulities.Remove(dificulity);
        }
    }
    public void ChangeTimeMode(bool value)
    {
        level.onTime = value;
        Console.WriteLine(level.onTime);
    }

 
}
