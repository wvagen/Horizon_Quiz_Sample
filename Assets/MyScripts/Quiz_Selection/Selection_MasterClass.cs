using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection_MasterClass : MonoBehaviour
{

    public Quiz_Game_Over_Manager gameOverManager;

    public AudioSource myAudioSource;
    public AudioClip successAudioClip, FailureAudioClip;

    public Button confirmBtn;

    Selection_Game_Suggestion selectedAnswer;

    void Start()
    {
        ConfirmBtnBehaviour(false);
    }

    public void Selected_Answer_Behaviour(Selection_Game_Suggestion selectedAnswer)
    {
        if (this.selectedAnswer) this.selectedAnswer.Diselect_Answer();
        ConfirmBtnBehaviour(true);
        this.selectedAnswer = selectedAnswer;
    }

    public void Confirm_Btn()
    {
        if (selectedAnswer.isRightAnswer)
        {
            myAudioSource.PlayOneShot(successAudioClip);
            selectedAnswer.Right_Answer_Behaviour();
            gameOverManager.WinLoseLevelManager(true, 3);
        }
        else
        {
            selectedAnswer.Wrong_Answer_Behaviour();
            myAudioSource.PlayOneShot(FailureAudioClip);
        }
    }

    void ConfirmBtnBehaviour(bool isConfirmEnabled)
    {
        Color confirmBtnCol = confirmBtn.GetComponent<Image>().color;
        if (isConfirmEnabled)
        {
            confirmBtn.enabled = true;
            confirmBtnCol.a = 1;
        }
        else
        {
            confirmBtn.enabled = false;
            confirmBtnCol.a = 0.5f;
        }

        confirmBtn.GetComponent<Image>().color = confirmBtnCol;
    }

}
