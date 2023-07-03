using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject uIPrompt;
    [SerializeField] private Animator _obstacleAnimator;
    private string usedParameter = "USED";

    public bool IsTriggered()
    {
        return _obstacleAnimator.GetBool(usedParameter);
    }
    public void Use()
    {
        if (!IsTriggered())
        {
            _obstacleAnimator.SetBool(usedParameter, true);
        }
    }
}
