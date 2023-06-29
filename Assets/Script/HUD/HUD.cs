using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public List<GameObject> HUDCheese;
    private float m_Time;

    // Update is called once per frame
    void Update()
    {
        m_Time += Time.deltaTime;
        TimeWrite();
    }

    private void TimeWrite()
    {
        string minutes = Mathf.Floor(m_Time / 60).ToString("00");
        string seconds = Mathf.Floor(m_Time % 60).ToString("00");

        Timer.text = string.Format("{0}:{1}", minutes, seconds);
    }

    public void CheeseDropped()
    {
        for (int i = HUDCheese.Count; i >= 0; i--)
        {
            if (HUDCheese[i].activeInHierarchy)
            {
                HUDCheese[i].SetActive(false);
                return;
            }
            else continue;
        }
    }

    public void CheesePickedUp()
    {
        for (int i = 0; i <= HUDCheese.Count; i++)
        {
            if (!HUDCheese[i].activeInHierarchy)
            {
                HUDCheese[i].SetActive(true);
                return;
            }
            else continue;
        }
    }
}
