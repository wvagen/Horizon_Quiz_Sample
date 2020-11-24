using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Match_MasterClass : MonoBehaviour
{

    public Vector3 mousePos;
    public ActivityMatch selectedOne;
    //public InstructionsPanel instPanel;
    public Vector2[] rightAnswers;

    static bool isRetrying = false;

    short pointCount = 0;

    void Start()
    {
        HelpBtn();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
    }

    public void HelpBtn()
    {
        if (isRetrying) Debug.Log("هناك خطأ أعد مرة أخرى");
        else Debug.Log("أربط بسهم");
        isRetrying = false;

    }

    public void confirm()
    {

        if (pointCount == rightAnswers.Length)
        {
            Debug.Log("أحسنت");
            isRetrying = false;
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

        if (rightAnswers[part1Indice].y == part2Indice)
        {
            pointCount++;
        }

    }

}
