using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

/// 
/// ?????? ?????? ???????????? ?????????????? ?????? ??????? ??????
/// 
/// 


public class GameScript : MonoBehaviour
{
    //??????????? ????????? ?????????? ???????
    public Question[] questions; //??????????? ?????? ????????
    public TextMeshProUGUI[] answersText;
    public TextMeshProUGUI qText;
    public bool levelOnTime;

    //??????????? ????????? ? ?????????? ?????????? ????????? ????
    public GameObject endGamePanel;
    public GameObject timer;

    public TextMeshProUGUI rightAnswersText;
    public TextMeshProUGUI wrongAnswersText;
    public int rightAnswersCounter;
    public int wrongAnswersCounter;
  
    //??????????? ?????????? ????????
    public AnswerInterface answerInterface;
    List<object> qList; //??????? ????????
    Question crntQ; //??????? ??????
    int randQuestionId; //????? ?????????? ???????

    public void Start()
    {
        //???????? ???????? ?? ???????
        Debug.Log("???????? ????????");
        questions = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().level.levelQuestionsData;
        levelOnTime = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().level.onTime;
        
        //????? ?? ????
        Debug.Log("???????? ????? Menu");
        SceneManager.UnloadSceneAsync("Menu");
        //?????????? ????????? ???? ??????
        endGamePanel.SetActive(false);

        qList = new List<object>(questions); //??????????? ?????? ????????
        questionGenerate(); //????????? ???????
        if (levelOnTime)
        {
            timer.SetActive(true);
        }
    }

    void questionGenerate()
    {
        if (qList.Count > 0) //???????? ?? ??????? ???????????? ????????
        {
            randQuestionId = Random.Range(0, qList.Count); //????????? ?????????? ?????????????????? ?????? ???????
            crntQ = qList[randQuestionId] as Question; //????? ?????????? ???????
            qText.text = crntQ.question; //????? ???????? ???????
            List<string> answers = new List<string>(crntQ.answers); //??????????? ?????? ??????? ?? ??????
            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
        }
        else //?????????? ????
        {
            endLevel();
        }

        
    }
    public void endLevel()
    {
        print("?? ?????? ????");
        rightAnswersText.SetText(rightAnswersCounter.ToString()); //???????? ?????????? ?????????? ?????????? ???????
        wrongAnswersText.SetText(wrongAnswersCounter.ToString()); //???????? ?????????? ?????????? ???????????? ???????
        endGamePanel.SetActive(true); //????????? ?????? ?????? ????
        timer.SetActive(false); //?????????? ???????
        timer.GetComponent<Timer>().resetTimer();
    }
    public void AnswerBttns(int index) //??????? ????????? ??????? ?????? ?????? ?? ??????
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) //???????? ?? ???????????? ??????
        {
            print("?????????? ?????");
            rightAnswersCounter++; //?????????? ???????? ?????????? ??????? ?? ??????
            qList.RemoveAt(randQuestionId); //???????? ??????? ?? ???????
            timer.GetComponent<Timer>().addTime();
            questionGenerate();
        }

        else
        {
            print("???????????? ?????");
            wrongAnswersCounter++; //?????????? ???????? ???????????? ??????? ?? ??????
            qList.RemoveAt(randQuestionId); //???????? ??????? ?? ???????
            questionGenerate();
            //answerInterface.DrawAllWrong();
        }
    }

    public void ExitToMenu() //????? ?? ??????
    {
        Debug.Log("???????? ????? Menu");

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}


