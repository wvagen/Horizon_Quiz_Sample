using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz_Game_Manager : MonoBehaviour
{

    public Quiz_Game_Over_Manager quizGameOverManager;

    public GameObject[] quizLevels;

    public AudioClip[] instructionsOptions;
    public string[] instructions;

    public AudioSource myAudioSource;

    public static byte currentLevelIndex = 0;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Enable_Level_With_Index();
    }

    public void Next_Level()
    {
        if (currentLevelIndex < quizLevels.Length)
        {
            quizGameOverManager.WinLoseLevelManager(true, 3);
        }
    }

    public void Lose_Level()
    {
        quizGameOverManager.WinLoseLevelManager(false);
    }

    void Enable_Level_With_Index()
    {
        if (currentLevelIndex < quizLevels.Length)
        {
            quizLevels[currentLevelIndex].SetActive(true);
            if (Quiz_Game_Over_Manager.sfxOn)
            myAudioSource.PlayOneShot(instructionsOptions[currentLevelIndex]);
            quizGameOverManager.instructionsTxt.text = instructions[currentLevelIndex];
        }
        else
        {
            quizGameOverManager.Set_Level_As_Finished();
            quizGameOverManager.Quit();
        }
    }



}
