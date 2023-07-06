using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI SceneName;
    public TextMeshProUGUI Timer;
    public List<Image> HUDCheese;
    private float m_Time;

    private void Start()
    {
        WriteSceneName();
    }

    // Update is called once per frame
    void Update()
    {
        m_Time = Time.time;
        //m_Time += Time.deltaTime;
        TimeWrite();
    }

    private void WriteSceneName()
    {
        SceneName.text = SceneManager.GetActiveScene().name;
    }
    private void TimeWrite()
    {
        string minutes = Mathf.Floor(m_Time / 60).ToString("00");
        string seconds = Mathf.Floor(m_Time % 60).ToString("00");

        Timer.text = string.Format("{0}:{1}", minutes, seconds);
    }

    public void HUDCheeseRefresh(int count)
    {
        foreach (Image image in HUDCheese)
        {
            image.enabled = false;
        }

        for (int i = 0; i < count; i++) 
        {
            HUDCheese[i].enabled = true;
        }
    }

    public void CheeseDropped()
    {
        //HUDCheese.Last().enabled = false;
        //m_NotActiveCheese.Add(HUDCheese.Last());
        //HUDCheese.Remove(HUDCheese.Last());

        for (int i = HUDCheese.Count; i >= 0; i--)
        {
            if (HUDCheese[i].enabled)
            {
                HUDCheese[i].enabled = false;
                return;
            }
            else continue;
        }
    }

    public void CheesePickedUp()
    {
        //m_NotActiveCheese.Last().enabled = true;
        //HUDCheese.Add(m_NotActiveCheese.Last());
        //m_NotActiveCheese.Remove(m_NotActiveCheese.Last());

        for (int i = 0; i <= HUDCheese.Count; i++)
        {
            if (!HUDCheese[i].enabled)
            {
                HUDCheese[i].enabled = true;
                return;
            }
            else continue;
        }
    }
}
