using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void FadeNextLevel()
    {
        this._animator.SetTrigger("FADEOUT");
    }
}
