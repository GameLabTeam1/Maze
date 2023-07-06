using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SoundManager : MonoBehaviour
{
    [Tooltip("Mouse click on menu options")]
    public AudioSource MenuClick;
    [SerializeField] public string MenuClickName;

    [Tooltip("Sound effect for the back button, if it's empty it will be the same as the menu click")]
    public AudioSource BackButtonClick;

    [Tooltip("Sound effect that plays when the mouse goes on 'play' button, if it's empty it will be disactivated")]
    public AudioSource MouseOnPlaySFX;
    [Tooltip("Sound effect that plays when the mouse goes on 'quit' button, if it's empty it will be disactivated")]
    public AudioSource MouseOnQuitSFX;
    [Tooltip("Sound effect that plays when the mouse goes on 'options' button, if it's empty it will be disactivated")]
    public AudioSource MouseOnOptionsSFX;
    [Tooltip("Sound effect that plays when the mouse goes on 'credits' button, if it's empty it will be disactivated")]
    public AudioSource MouseOnCreditsSFX;
    [Tooltip("Sound effect that plays when the mouse goes on 'video' button, if it's empty it will be disactivated")]
    public AudioSource MouseOnVideoSFX;
    [Tooltip("Sound effect that plays when the mouse goes on 'audio' button, if it's empty it will be disactivated")]
    public AudioSource MouseOnAudioSFX;

    [Tooltip("Sound effect for the play button, if it's empty it will be the same as the menu click")]
    public AudioSource PlayButtonClick;

    [Tooltip("Do you want sfx when mouse is o a button? add the fucking audio clip then, shithead")]
    public bool MouseOnButtonSound = true;


    /// <summary>
    /// Play the sound matched with the play button
    /// </summary>
    public void PlayPlaySound()
    {
        if (PlayButtonClick.clip == null) PlayButtonClick = MenuClick;
        PlaySound(PlayButtonClick.clip, PlayButtonClick);
    }

    /// <summary>
    /// Play the sound matched with the "back" button
    /// </summary>
    public void PlayBackButton()
    {
        if (BackButtonClick.clip == null) BackButtonClick = MenuClick;
        PlaySound(BackButtonClick.clip, BackButtonClick);
    }

    /// <summary>
    /// Play the sound matched with the click on a option
    /// </summary>
    public void PlayMenuClick()
    {
        PlaySound(MenuClick.clip, MenuClick);
    }

    //List of methods that play sound when the mouse pointer enters the specified button (Play, Quit, Options ecc)

    public void MouseOnPlay()
    {
        if (MouseOnButtonSound)
        {
            PlaySound(MouseOnPlaySFX.clip, MouseOnPlaySFX);
        }
    }
    public void MouseOnOptions()
    {
        if (MouseOnButtonSound)
        {
            PlaySound(MouseOnOptionsSFX.clip, MouseOnOptionsSFX);
        }
    }
    public void MouseOnQuit()
    {
        if (MouseOnButtonSound)
        {
            PlaySound(MouseOnQuitSFX.clip, MouseOnQuitSFX);
        }
    }
    public void MouseOnCredits()
    {
        if (MouseOnButtonSound)
        {
            PlaySound(MouseOnCreditsSFX.clip, MouseOnCreditsSFX);
        }
    }
    public void MouseOnAudio()
    {
        if (MouseOnButtonSound)
        {
            PlaySound(MouseOnAudioSFX.clip, MouseOnAudioSFX);
        }
    }
    public void MouseOnVideo()
    {
        if (MouseOnButtonSound)
        {
            PlaySound(MouseOnVideoSFX.clip, MouseOnVideoSFX);
        }
    }

    //List of methods that stop sound when the mouse pointer exits the specified button (Play, Quit, Options ecc)

    public void StopMousePlay()
    {
        if (MouseOnButtonSound)
        {
            StopSound(MouseOnPlaySFX.clip, MouseOnPlaySFX);
        }
    }
    public void StopMouseQuit()
    {
        if (MouseOnButtonSound)
        {
            StopSound(MouseOnQuitSFX.clip, MouseOnQuitSFX);
        }
    }
    public void StopMouseOptions()
    {
        if (MouseOnButtonSound)
        {
            StopSound(MouseOnOptionsSFX.clip, MouseOnOptionsSFX);
        }
    }
    public void StopMouseCredits()
    {
        if (MouseOnButtonSound)
        {
            StopSound(MouseOnCreditsSFX.clip, MouseOnCreditsSFX);
        }
    }
    public void StopMouseAudio()
    {
        if (MouseOnButtonSound)
        {
            StopSound(MouseOnAudioSFX.clip, MouseOnAudioSFX);
        }
    }
    public void StopMouseVideo()
    {
        if (MouseOnButtonSound)
        {
            StopSound(MouseOnVideoSFX.clip, MouseOnVideoSFX);
        }
    }

    /// <summary>
    /// Used to play generic sound
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="source"></param>
    public void PlaySound(AudioClip clip, AudioSource source)
    {
        Debug.Log("Playing: " + source.name);
        source.clip = clip;
        source.Play();

    }


    /// <summary>
    /// Used to stop generic sound
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="source"></param>
    public void StopSound(AudioClip clip, AudioSource source)
    {
        Debug.Log("Stopped playing: " + source.name);
        source.clip = clip;
        source.Stop();
    }

}