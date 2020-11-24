using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnswer_Game_Suggestion : MonoBehaviour
{
    public SldieAnswer_MasterClass slideAnswerMasterClass;

    public AudioSource myAudioSource;
    public AudioClip myAnswerClip;

    public Vector2 initPos;

    public bool isRightAnswer = false;

    bool isHolding = false,isSnapped = false;


    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        if (isHolding && !isSnapped) HoldingBehaviour();
    }

    void HoldingBehaviour()
    {
      Vector2 fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      transform.position = fingerPos;
    }

    public void OnPointerDown()
    {
        isHolding = true;
        isSnapped = false;
    }

    public void OnPointerUp()
    {
        isHolding = false;
        slideAnswerMasterClass.Snap_Drop_Area_Behaviour(this);
    }

    public void Snap_Me(Vector3 snapPos, bool isSnapped)
    {
        this.isSnapped = isSnapped;
        transform.position = snapPos;
    }

    public void Listen_To_Answer_Btn()
    {
        myAudioSource.PlayOneShot(myAnswerClip);
    }

}
