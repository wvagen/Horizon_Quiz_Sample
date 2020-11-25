using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SldieAnswer_MasterClass : MonoBehaviour
{

    public Quiz_Game_Manager gameManager;

    public Transform dropAreaTransform;

    public AudioSource myAudioSource;
    public AudioClip successAudioClip, FailureAudioClip;

    public Button confirmBtn;

    SlideAnswer_Game_Suggestion sliderGameSugg;

    bool isFilled =false;

    const float MIN_DISTANCE_TO_SNAP = 2.5f;
    void Start()
    {
        ConfirmBtnBehaviour(false);
    }



    public void Confirm_Btn()
    {
        if (this.sliderGameSugg.isRightAnswer)
        {
            myAudioSource.PlayOneShot(successAudioClip);
            gameManager.Next_Level();
        }
        else
        {
            gameManager.Lose_Level();
            myAudioSource.PlayOneShot(FailureAudioClip);
        }
    }

    public void Snap_Drop_Area_Behaviour(SlideAnswer_Game_Suggestion sliderGameSugg)
    {
        if (!isFilled && Vector2.Distance(sliderGameSugg.transform.position, dropAreaTransform.position) <= MIN_DISTANCE_TO_SNAP)
        {
            sliderGameSugg.Snap_Me(dropAreaTransform.position, true);
            this.sliderGameSugg = sliderGameSugg;
            isFilled = true;
            ConfirmBtnBehaviour(true);
        }
        else
        {
            sliderGameSugg.Snap_Me(sliderGameSugg.initPos, false);
            if (this.sliderGameSugg && this.sliderGameSugg.Equals(sliderGameSugg) && isFilled)
            {
                isFilled = false;
                ConfirmBtnBehaviour(false);
            }
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
