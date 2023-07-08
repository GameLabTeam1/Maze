using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject _requiredKey;
    private KeyInventory _keyInventory;
    private Animator _doorAnim;
    private UIDialogue _uiDialogue;
    public GameObject _uIPrompt;
    public string missingKey;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _keyInventory = player.GetComponent<KeyInventory>();
        _uiDialogue = player.GetComponent<UIDialogue>();
        _doorAnim = GetComponent<Animator>();
    }

    public void Open()
    {
        if (_keyInventory.HasKey(_requiredKey))
        {
            _doorAnim.SetBool("KEY", true);
        }
        else
        {
            _uiDialogue.ShowDialogue(missingKey);
        }
    }    
}
