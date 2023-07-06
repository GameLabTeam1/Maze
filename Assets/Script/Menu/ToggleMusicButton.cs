using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicButton : MonoBehaviour
{
    public Slider MusicSlider;
    public Image MusicCheck;
    private bool m_ActiveMusic = true;

    public void ToggleMusic()
    {
        if (m_ActiveMusic)
        {
            Debug.Log("MusicOn");
            //AkSoundEngine.SetRTPCValue("MusicVolume", 0f);
            MusicCheck.color = Color.grey;
            m_ActiveMusic = false;
            return;
        }

        if (!m_ActiveMusic)
        {
            Debug.Log("MusicOff");
            //AkSoundEngine.SetRTPCValue("MusicVolume", MusicSlider.value);
            MusicCheck.color = Color.cyan;
            m_ActiveMusic = true;
            return;
        }
    }
}
