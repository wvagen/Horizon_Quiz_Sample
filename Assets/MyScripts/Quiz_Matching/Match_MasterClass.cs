using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Match_MasterClass : MonoBehaviour
{
    public Quiz_Game_Manager gameManager;

    public Vector3 mousePos;
    public ActivityMatch selectedOne;
    //public InstructionsPanel instPanel;
    public Vector2[] rightAnswers;

    short pointCount = 0;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }


    public void confirm()
    {

        if (pointCount == rightAnswers.Length)
        {
            gameManager.Next_Level();
        }
        else
        {
            gameManager.Lose_Level();
        }

    }

    public void SetNewLinePos(Vector2 newPos)
    {
        selectedOne.isPressed = false;
        selectedOne.myLine.SetPosition(1, newPos);
        selectedOne.isMatchedFunction();
    }

    public void CheckTheSolution(short part1Indice, short part2Indice)
    {

        if (Mathf.Abs(rightAnswers[part1Indice].y - part2Indice) < 0.1f)
        {
            pointCount++;
        }

    }

}
