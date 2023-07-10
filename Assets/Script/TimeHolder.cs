using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeHolder : MonoBehaviour
{
    private float _TimeHolder = 0f;

    public void SaveSceneTime(float currentTimer)
    {
        _TimeHolder = currentTimer;
        PlayerPrefs.SetFloat("Saved Time", _TimeHolder);

    }

    public void LoadSceneTime(float currentTimer)
    {
        currentTimer = PlayerPrefs.GetFloat("Saved Time");
    }
}
