using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(true);
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogue.SetActive(false);
            Debug.Log("Exit");
        }
    }
}
