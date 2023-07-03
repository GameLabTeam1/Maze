using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeDialogue : MonoBehaviour
{
    public GameObject uIPrompt;
    [SerializeField, TextArea(10, 10)]
    public string dialogueText;
}
