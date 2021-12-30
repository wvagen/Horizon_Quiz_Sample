using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question_Behaviour : MonoBehaviour
{

    public AudioSource myAudioSource;
    public AudioClip myAudioClip;

    public void PlayQuestionSound()
    {
        if (myAudioClip && Quiz_Game_Over_Manager.sfxOn)
        myAudioSource.PlayOneShot(myAudioClip);
    }

}
