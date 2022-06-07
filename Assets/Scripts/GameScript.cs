using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

/// 
/// Данный скрипт осуществляет взаимодействие внутри игровой сессии
/// 
/// 


public class GameScript : MonoBehaviour
{
    //Определение элементов интерфейса вопроса
    public Question[] questions; //Определение списка вопросов
    public TextMeshProUGUI[] answersText;
    public TextMeshProUGUI qText;
    public bool levelOnTime;

    //Определение элементов и переменных интерфейса итогового окна
    public GameObject endGamePanel;
    public GameObject timer;

    public TextMeshProUGUI rightAnswersText;
    public TextMeshProUGUI wrongAnswersText;
    public int rightAnswersCounter;
    public int wrongAnswersCounter;
  
    //Определение переменных вопросов
    public AnswerInterface answerInterface;
    List<object> qList; //Очередь вопросов
    Question crntQ; //Текущий вопрос
    int randQuestionId; //Номер случайного вопроса

    public void Start()
    {
        //Загрузка вопросов на уровень
        Debug.Log("Загрузка вопросов");
        questions = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().level.levelQuestionsData;
        levelOnTime = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().level.onTime;
        
        //Выход из меню
        Debug.Log("Выгрузка сцены Menu");
        SceneManager.UnloadSceneAsync("Menu");
        //Выключение итогового окна уровня
        endGamePanel.SetActive(false);

        qList = new List<object>(questions); //Определение списка вопросов
        questionGenerate(); //Генерация вопроса
        if (levelOnTime)
        {
            timer.SetActive(true);
        }
    }

    void questionGenerate()
    {
        if (qList.Count > 0) //Проверка на наличие неотвеченных вопросов
        {
            randQuestionId = Random.Range(0, qList.Count); //Генерация случайного идентификационного номера вопроса
            crntQ = qList[randQuestionId] as Question; //выбор случайного вопроса
            qText.text = crntQ.question; //текст текущего вопроса
            List<string> answers = new List<string>(crntQ.answers); //Определение списка ответов на вопрос
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else //завершение игры
        {
            endLevel();
        }

        
    }
    public void endLevel()
    {
        print("Вы прошли игру");
        rightAnswersText.SetText(rightAnswersCounter.ToString()); //Передача интерфейсу количества правильных ответов
        wrongAnswersText.SetText(wrongAnswersCounter.ToString()); //Передача интерфейсу количества неправильных ответов
        endGamePanel.SetActive(true); //Включение панели итогов игры
        timer.SetActive(false); //Выключение таймера
        timer.GetComponent<Timer>().resetTimer();
    }
    public void AnswerBttns(int index) //Функция обработки нажатия кнопки ответа на вопрос
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) //Проверка на правильность ответа
        {
            print("Правильный ответ");
            rightAnswersCounter++; //Увеличение счетчика правильных ответов на вопрос
            qList.RemoveAt(randQuestionId); //Удаление вопроса из очереди
            timer.GetComponent<Timer>().addTime();
            questionGenerate();
        }

        else
        {
            print("Неправильный ответ");
            wrongAnswersCounter++; //Увеличение счетчика неправильных ответов на вопрос
            qList.RemoveAt(randQuestionId); //Удаление вопроса из очереди
            questionGenerate();
            //answerInterface.DrawAllWrong();
        }
    }

    public void ExitToMenu() //Выход из уровня
    {
        Debug.Log("Загрузка сцены Menu");

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}


