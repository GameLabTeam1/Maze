using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject uIPrompt;
    private Animator _obstacleAnimator;
    private string _usedParameter = "USED";

    private void Start()
    {
        _obstacleAnimator = GetComponent<Animator>();
    }

    public bool IsTriggered()
    {
        return _obstacleAnimator.GetBool(_usedParameter);
    }
    public void Use()
    {
        if (!IsTriggered())
        {
            _obstacleAnimator.SetBool(_usedParameter, true);
        }
    }
}
