using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{
    public Question[] questionsData;
    public Question[] filteredQuestions;
    public Dropdown catergoryDropdownElement;

    public void StartGame()
    {
        //Question[] filteredQuestions = filteredQuestionsList.ToArray(); //����� ������������� ������������� ������ �������� �� ������������� � ������
        if (catergoryDropdownElement.value == 0)
        {
            filteredQuestions = questionsData;
        }
            
       Debug.Log("�������� ����� TestLevel");
       SceneManager.LoadScene("TestLevel", LoadSceneMode.Additive);

    }
    public void ChangeQuestionCategory(int value)
    {
        switch (value)
        {
            case 0:
                filteredQuestions = questionsData;
                break;
            case 1:
                Debug.Log("��������� �������� - ��������");
                filteredQuestions = QuestionListFilterByCategory(Question.questionCategory.Geography);
                break;
            case 2:
                Debug.Log("��������� �������� - �������");
                filteredQuestions = QuestionListFilterByCategory(Question.questionCategory.History);
                break;
            case 3:
                Debug.Log("��������� �������� - ������");
                filteredQuestions = QuestionListFilterByCategory(Question.questionCategory.Music);
                break;
            case 4:
                Debug.Log("��������� �������� - ����");
                filteredQuestions = QuestionListFilterByCategory(Question.questionCategory.Games);
                break;
        }
    }
    public void ChangeQuestionDificulity(bool value)
    {
        print(value);
    }

    private Question[] QuestionListFilterByCategory(Question.questionCategory filter)
    {
        List<Question> filteredQuestionsList = new List<Question>();
        foreach (var question in questionsData)
        {
            if(question.category == filter)
            {
                filteredQuestionsList.Add(question);
            }
        }
        Question[] filteredQuestions = filteredQuestionsList.ToArray();
        return filteredQuestions;
    }
    private Question[] QuestionListFilterByDificulity(Question.questionDificulity filter)
    {
        List<Question> filteredQuestionsList = new List<Question>();
        foreach (var question in questionsData)
        {
            if (question.dificulity == filter)
            {
                filteredQuestionsList.Add(question);
            }
        }
        Question[] filteredQuestions = filteredQuestionsList.ToArray();
        return filteredQuestions;
    }
}
