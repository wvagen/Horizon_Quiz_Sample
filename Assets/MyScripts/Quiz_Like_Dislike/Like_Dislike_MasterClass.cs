using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Like_Dislike_MasterClass : MonoBehaviour
{
    public Quiz_Game_Over_Manager quizGOMan;

    public bool isChoiceSelected = false;
    public void Select_A_Choice(Like_Dislike_Suggestion selectedAnswer)
    {
        StartCoroutine(Win_Level());
    }

    IEnumerator Win_Level()
    {
        yield return new WaitForSeconds(2);
        quizGOMan.WinLoseLevelManager(true, 3);
    }

}
