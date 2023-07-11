using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeHolder : MonoBehaviour
{
    public TextMeshProUGUI totalTime;
    private float _TimeHolder = 0f;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SaveSceneTime(float currentTimer)
    {
        _TimeHolder = currentTimer;
        PlayerPrefs.SetFloat("Saved Time", _TimeHolder);
    }

    public float LoadSceneTime()
    {
        return PlayerPrefs.GetFloat("Saved Time");
    }

    private void Update()
    {
        if (totalTime != null)
        {
            float totalTimer = PlayerPrefs.GetFloat("Saved Time");
            string minutes = Mathf.Floor(totalTimer / 60).ToString("00");
            string seconds = Mathf.Floor(totalTimer % 60).ToString("00");

            totalTime.text = string.Format("{0}:{1}", minutes, seconds);
        }
    }

}
