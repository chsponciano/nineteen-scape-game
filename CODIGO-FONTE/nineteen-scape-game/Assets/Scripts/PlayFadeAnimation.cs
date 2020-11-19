using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFadeAnimation : MonoBehaviour
{
    public Animator animator;

    public void PlayGameFade()
    {
        animator.SetTrigger("game");
    }
}
