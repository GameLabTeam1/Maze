using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    public void ShowDialogue(string text)
    {
        dialogueText.text = text;
        dialoguePanel.SetActive(true);
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
