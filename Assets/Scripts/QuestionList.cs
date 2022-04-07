using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Question
{
    public enum questionCategory
    {
        History,
        Geography,
        Music,
        Games,
        Literature,
        Cinema
    }
    public enum questionDificulity
    {
        Easy,
        Medium,
        Hard
    }

    public string question;
    public questionCategory category;
    public questionDificulity dificulity;
    public string[] answers = new string[3];

    
}
