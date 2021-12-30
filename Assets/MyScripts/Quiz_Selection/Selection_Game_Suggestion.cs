using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection_Game_Suggestion : MonoBehaviour
{
    public Selection_MasterClass quizMasterManager;
    public AudioSource myAudioSource;
    public AudioClip myAudioClip;

    public Image frameImg;
    public Sprite rightAnswerFrame, wrongAnswerFrame, selectedAnswerFrame;

    public bool isRightAnswer = false;

    Sprite initSelectedFrame;

    void Start()
    {
        initSelectedFrame = frameImg.sprite;
    }

    public void PlayAnswerSound()
    {
        if (myAudioClip && Quiz_Game_Over_Manager.sfxOn)
            myAudioSource.PlayOneShot(myAudioClip);
    }

    public void Select_Answer()
    {
        quizMasterManager.Selected_Answer_Behaviour(this);
        frameImg.sprite = selectedAnswerFrame;
    }

    public void Diselect_Answer()
    {
        frameImg.sprite = initSelectedFrame;
    }

    public void Right_Answer_Behaviour()
    {
        frameImg.sprite = rightAnswerFrame;
    }

    public void Wrong_Answer_Behaviour()
    {
        frameImg.sprite = wrongAnswerFrame;
    }

}
