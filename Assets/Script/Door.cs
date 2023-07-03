using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject requiredKey;
    private KeyInventory inventory;
    [SerializeField] private Animator _doorAnim;

    private void Start()
    {
        inventory = FindObjectOfType<KeyInventory>();
    }

    public void Open()
    {
        if (inventory.HasKey(requiredKey))
        {
            _doorAnim.SetBool("KEY", true);
            Debug.Log("La porta si è aperta!");
        }
        else
        {
            Debug.Log("Non hai la chiave");
        }
    }
}
