using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Like_Dislike_Suggestion : MonoBehaviour
{
    public Like_Dislike_MasterClass masterClass;

    bool isSelected = false;
    public void Select_Me()
    {
        if (!masterClass.isChoiceSelected && !isSelected)
        {
            isSelected = true;
            masterClass.isChoiceSelected = true;
            masterClass.Select_A_Choice(this);
            StartCoroutine(Rotate_Animation_Coroutine());
        }
    }

    IEnumerator Rotate_Animation_Coroutine()
    {
        while (true)
        {
            transform.Rotate(Vector2.up * Time.deltaTime * 400);
            yield return new WaitForEndOfFrame();
        }
    }
}
