using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    public Button Button;
    public Animator ButtonAnimator;
    public string AnimationName;
    public bool HasAnimations = false;

    private void Start()
    {

        if (HasAnimations)
        {
            if (ButtonAnimator == null)
            {
                ButtonAnimator = Button.GetComponent<Animator>();
            }

            ButtonAnimator.enabled = false;
        }
    }

    #region Animation
    public void PlayAnimation()
    {
        if (ButtonAnimator != null)
        {
            ButtonAnimator.enabled = true;
            ButtonAnimator.Play(AnimationName, -1, 0f);
        }
    }

    public void StopAnimation()
    {
        if (ButtonAnimator != null)
        {
            ButtonAnimator.enabled = false;
        }
    }
    #endregion
}
