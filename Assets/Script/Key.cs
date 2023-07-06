using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Key : MonoBehaviour
{
    [SerializeField]
    private KeyInventory _keyInventory;
    public GameObject uIPrompt;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _keyInventory = player.GetComponent<KeyInventory>();
    }

    public void AddKey()
    {
        _keyInventory.AddKey(this.gameObject);
        this.gameObject.SetActive(false);
    }    
}
